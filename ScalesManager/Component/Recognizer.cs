using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using openalprnet;
using System.Text.RegularExpressions;
using log4net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Drawing.Imaging;

namespace ScalesManager.Component
{
    public class Recognizer
    {
        private static Recognizer instance;

        private static readonly ILog log = LogManager.GetLogger(typeof(Recognizer));
        private static readonly HttpClient client = new HttpClient();

        private Recognizer() { }

        public static Recognizer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Recognizer();
                    client.Timeout = TimeSpan.FromSeconds(12);
                }
                return instance;
            }
        }

        public AlprPlateNet Recognize(Bitmap img)
        {
            if (img == null)
                return null;
            var alpr = new AlprNet("eu", "openalpr.conf", "runtime_data");
            if (!alpr.IsLoaded())
            {
                Console.WriteLine("OpenAlpr failed to load!");
                return null;
            }

            // Optionally apply pattern matching for a particular region
            //alpr.DefaultRegion = "eu";

            var results = alpr.Recognize(img);

            Regex bsx5So = new Regex(@"^\d{2}[A-Z]\d{5}$");     //format bien 5 so
            Regex bsx4So = new Regex(@"^\d{2}[A-Z]\d{4}$");     //format bien 4 so            
            try
            {
                foreach (var result in results.Plates)
                {
                    // crop plate
                    List<Point> platePoints = result.PlatePoints;
                    Bitmap cropedPlate = img.Clone(boundingRectangle(platePoints), img.PixelFormat);

                    foreach (var plate in result.TopNPlates)
                    {
                        if (bsx5So.IsMatch(plate.Characters) || bsx4So.IsMatch(plate.Characters))
                        {
                            // bỏ qua biển số rờ mooc 
                            if (plate.Characters.Contains("R"))
                                return null;

                            Utilities.BienSoXe = cropedPlate;
                            return plate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi lay bien so xe");
                log.Error(ex.Message);
                log.Error(ex.StackTrace);
            }
            return null;
        }

        public Rectangle boundingRectangle(List<Point> points)
        {
            // Add checks here, if necessary, to make sure that points is not null,
            // and that it contains at least one (or perhaps two?) elements

            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            return new Rectangle(new Point(minX, minY), new Size(maxX - minX, maxY - minY));
        }

        public string ProcessImageImmediately(byte[] imgData)
        {
            //string SECRET_KEY = "sk_f77fe161fcb3196bbafc3ba6";
            string SECRET_KEY = ConfigurationManager.AppSettings.Get("SECRET_KEY");

            string imagebase64 = Convert.ToBase64String(imgData);
            var content = new StringContent(imagebase64);

            //HttpClient client = new HttpClient();
            //client.Timeout = TimeSpan.FromSeconds(12);

            HttpResponseMessage response = 
                client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=eu&secret_key=" + SECRET_KEY, content).Result;            
            
            var byteArray = response.Content.ReadAsByteArrayAsync().Result;            
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            return responseString;
        }


        public static async Task<string> ProcessImage(byte[] imgData)
        {
            //string SECRET_KEY = "sk_f77fe161fcb3196bbafc3ba6";
            string SECRET_KEY = ConfigurationManager.AppSettings.Get("SECRET_KEY");

            string imagebase64 = Convert.ToBase64String(imgData);

            var content = new StringContent(imagebase64);

            //HttpClient client = new HttpClient();
            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=0&country=eu&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return responseString;
        }

        public async Task<string> RegconizeTwoLinePlate(Bitmap img)
        {
            if (img == null)
                return null;

            string plateNumber = null;
            try
            {
                // convert img to byte array
                ImageConverter converter = new ImageConverter();
                byte[] bytes = (byte[])converter.ConvertTo(img, typeof(byte[]));

               //compress image
                byte[] compressed = Compress(bytes);

                log.Info("Bat dau xu ly bien so vuong");

                // invoke api
                //Task<string> recognizeTask = Task.Run(() => ProcessImage(compressed));
                //recognizeTask.Wait();
                //string task_result = recognizeTask.Result;
                string task_result = await Task.Run(() => ProcessImage(compressed));

                //string task_result = ProcessImageImmediately(compressed);

                log.Info("Ket thuc xu ly bien so vuong");
                
                if (string.IsNullOrWhiteSpace(task_result))
                    return null;

                // get plate number
                log.Info("Lay chuoi ky tu bien so");
                JObject response = JObject.Parse(task_result);
                plateNumber = (string)response.SelectToken("results[0].plate");
                if (string.IsNullOrWhiteSpace(plateNumber))
                    return null;

                // bỏ qua biển số rờ mooc 
                if (plateNumber.Contains("R"))
                    return null;

                // crop plate
                log.Info("Crop bien so");
                JArray a = (JArray)response.SelectToken("results[0].coordinates");
                if (a == null)
                    return null;
                List<Point> platePoints = new List<Point>();
                for (int i = 0; i < a.Count; i++)
                {
                    int x = (int)a[i].SelectToken("x");
                    int y = (int)a[i].SelectToken("y");
                    Point point = new Point(x, y);
                    platePoints.Add(point);
                }

                Bitmap cropedPlate = img.Clone(boundingRectangle(platePoints), img.PixelFormat);
                Utilities.BienSoXe = cropedPlate;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                log.Error(ex.StackTrace);
            }          

            return plateNumber;
        }

        //compress an image
        public byte[] Compress(byte[] data)
        {
            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            using (var inStream = new MemoryStream(data))
            using (var outStream = new MemoryStream())
            {
                var image = Image.FromStream(inStream);

                // if we aren't able to retrieve our encoder
                // we should just save the current image and
                // return to prevent any exceptions from happening
                if (jpgEncoder == null)
                {
                    image.Save(outStream, ImageFormat.Jpeg);
                }
                else
                {
                    var qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(qualityEncoder, 50L);
                    image.Save(outStream, jpgEncoder, encoderParameters);
                }

                return outStream.ToArray();
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        //resize an image
        public byte[] Resize(byte[] data, int width)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = Image.FromStream(stream);

                var height = (width * image.Height) / image.Width;
                var thumbnail = image.GetThumbnailImage(width, height, null, IntPtr.Zero);

                using (var thumbnailStream = new MemoryStream())
                {
                    thumbnail.Save(thumbnailStream, ImageFormat.Jpeg);
                    return thumbnailStream.ToArray();
                }
            }
        }
    }
}