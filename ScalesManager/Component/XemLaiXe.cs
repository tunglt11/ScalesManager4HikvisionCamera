using ScalesManager.Bussiness;
using ScalesManager.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public partial class XemLaiXe : Form
    {
         
        
        public XemLaiXe(string maphieu)
        {
            InitializeComponent();
            ShowCameraCaptureByMaphieu(maphieu);
        }

        public void ShowCameraCaptureByMaphieu(string maphieu)
        {
            PhieuCanCtrl phieuCanCtrl = new PhieuCanCtrl();
            PhieuCanInfo phieuCanInfo = phieuCanCtrl.LayCameraTheoPhieuCan(maphieu);
            pictureBox1.Image = phieuCanInfo.Cam1;
            pictureBox2.Image = phieuCanInfo.Cam2;
            pictureBox3.Image = phieuCanInfo.Cam3;
        }
    }
}
