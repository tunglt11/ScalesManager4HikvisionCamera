using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Bussiness;
using DevComponents.DotNetBar;

namespace ScalesManager.Component
{
    public partial class frmCauHinhCanTD : Office2007Form
    {
        CauHinhCanTDCtrl m_cauHinhCanTDCtrl = new CauHinhCanTDCtrl();
        public frmCauHinhCanTD()
        {
            InitializeComponent();
            txtThoiGian.Text = "10";
            txtKhoiLuong.Text = "200";
        }
        #region kiểm tra lỗi
        bool KtraRong()
        {
            if (txtKhoiLuong.Text != "" && txtKhoiLuong.Text != null &&
                txtThoiGian.Text != "" && txtThoiGian.Text != null)
                return true;
            else
                return false;
        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CauHinhCanTDInfo cauHinhCanTDInfo = new CauHinhCanTDInfo();
            if (KtraRong() == true)
            {
                try
                {
                    if (m_cauHinhCanTDCtrl.DemCauHinhCan() == 1)
                    {
                        cauHinhCanTDInfo.ID = m_cauHinhCanTDCtrl.LayIDCauHinh();
                        cauHinhCanTDInfo.TimeSleep = int.Parse(txtThoiGian.Text);
                        cauHinhCanTDInfo.KhoiLuong = decimal.Parse(txtKhoiLuong.Text);
                    m_cauHinhCanTDCtrl.LuuCauHinh_LanN(cauHinhCanTDInfo);
                    }
                    else
                    {
                    cauHinhCanTDInfo.ID = "CAUHINH";
                    cauHinhCanTDInfo.TimeSleep = int.Parse(txtThoiGian.Text);
                    cauHinhCanTDInfo.KhoiLuong = decimal.Parse(txtKhoiLuong.Text);
                    m_cauHinhCanTDCtrl.LuuCauHinh_Lan1(cauHinhCanTDInfo);
                    }
                    lbStatus.Text = "Lưu thành công!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    lbStatus.Text = "Lỗi!!!";
                }
            }
            else
                lbStatus.Text = "Nhập thiếu dữ liệu!!!";
        }

        private void txtKhoiLuong_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtKhoiLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThoiGian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
