using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public class ProtectedPictureBox : System.Windows.Forms.PictureBox
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProtectedPictureBox));

        protected override void OnPaint(PaintEventArgs e)
        {

            try
            {
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                log.Info("Start re-capture camera " + this.Name);
                switch (this.Name)
                {
                    case "cam1":
                        FormAutoScale.camTruoc.StartCapture();
                        break;
                    case "cam2":
                        FormAutoScale.camTruoc01.StartCapture();
                        break;
                    case "cam3":
                        FormAutoScale.camSau.StartCapture();
                        break;
                    case "cam4":
                        FormAutoScale.camToanCanh.StartCapture();
                        break;
                }

            }
        }
    }
}
