using log4net;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.UserInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private ProtectedPictureBox pictureBox;
        private bool IsCameraRunning { get => isCameraRunning; set => isCameraRunning = value; }
        private static readonly ILog log = LogManager.GetLogger(typeof(Camera));

        public Camera(String cameraAddress, ProtectedPictureBox pictureBox)
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
                OpenCvSharp.Size newSize = new OpenCvSharp.Size(854, 480);
                try
                {                    
                    while (isCameraRunning)
                    {
                        capture.Read(frame);
                        
                        frame.Resize(newSize);

                        if (pictureBox.Image != null)
                            pictureBox.Image.Dispose();

                        pictureBox.Image = BitmapConverter.ToBitmap(frame);

                        if (pictureBox.Image != null)
                            pictureBox.Refresh();

                        Thread.Sleep(10);
                    }
                }
                catch (Exception ex)
                {
                    isCameraRunning = false;
                    log.Error("Camera capture error: " + cameraAddress);
                    log.Error(ex.Message);
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
                log.Error("Can not take snapshot from camera: " + cameraAddress);
                log.Error(ex.StackTrace);
            }
            return null;
        }        
    }
}