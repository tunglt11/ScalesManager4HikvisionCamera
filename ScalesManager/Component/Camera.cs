using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public class Camera
    {
        private VideoCapture capture;
        private Mat frame;
        private bool isCameraRunning = false;        
        private readonly string cameraAddress;
        private PictureBox pictureBox;
        private bool IsCameraRunning { get => isCameraRunning; set => isCameraRunning = value; }
        private static object _locker = new object();

        public Camera(String cameraAddress, PictureBox pictureBox)
        {
            this.cameraAddress = cameraAddress;
            this.pictureBox = pictureBox;
        }

        public void StartCapture()
        {
            //new Thread(new ParameterizedThreadStart(CaptureCameraCallback)).Start(pictureBox);
            Thread captureThread = new Thread(new ThreadStart(CaptureCameraCallback));
            captureThread.IsBackground = true;
            captureThread.Start();
        }

        public void StopCapture()
        {
            if (capture != null)
            {
                isCameraRunning = false;
                capture.Release();
            }
        }

        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture();

            if (string.IsNullOrEmpty(cameraAddress))
                capture.Open(0);
            else
                capture.Open(cameraAddress);

            if (capture.IsOpened())
            {
                isCameraRunning = true;
                try
                {
                    while (isCameraRunning)
                    {                    
                        capture.Read(frame);

                        lock (_locker)
                        {
                            if (pictureBox.Image != null)
                                pictureBox.Image.Dispose();
                                //pictureBox.Invoke(new System.Action(() => pictureBox.Image.Dispose()));
                                                            
                            //pictureBox.Invoke(new System.Action(() => pictureBox.Image = BitmapConverter.ToBitmap(frame)));
                            pictureBox.Image = BitmapConverter.ToBitmap(frame);

                            if (pictureBox.Image != null)
                                pictureBox.Refresh();
                                //pictureBox.Invoke(new System.Action(() => pictureBox.Refresh()));
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    isCameraRunning = false;
                    Console.WriteLine("Camera capture error");
                    Console.Write(ex.Message);
                }
            }
        }

        public Bitmap TakeSnapshot()
        {
            try
            {
                return (isCameraRunning) ? BitmapConverter.ToBitmap(frame) : null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Can not take snapshot from camera: " + cameraAddress);
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }        
    }
}