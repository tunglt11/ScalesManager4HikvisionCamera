using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ScalesManager.Bussiness;
using ScalesManager.Controller;

namespace ScalesManager.Component
{
    public partial class frmThongTinCongTy : Office2007Form
    {
        CongTyCtrl m_congTyCtrl = new CongTyCtrl();
        CongTyInfo m_conTyInfo = new CongTyInfo();

        public frmThongTinCongTy()
        {
            InitializeComponent();
        }

        private void frmThongTinCongTy_Load(object sender, EventArgs e)
        {
            m_conTyInfo = m_congTyCtrl.LayThongTinCT();
            txtTenCT.Text = m_conTyInfo.TenCongTy;
            txtDiaChi.Text = m_conTyInfo.DiaChi;
            txtSDT.Text = m_conTyInfo.SDT;
            txtFax.Text = m_conTyInfo.Fax;
        }

        #region kiểm tra lỗi
        bool KtraRong()
        {
            if (txtTenCT.Text != "" && txtTenCT.Text != null &&
                txtDiaChi.Text != "" && txtDiaChi.Text != null)
                return true;
            else
                return false;
        }

        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CongTyInfo congTyInfo = new CongTyInfo();
            if (KtraRong() == true)
            {
                try
                {
                    if (m_congTyCtrl.DemThongTinCT() == 1)
                    {
                        congTyInfo.ID = m_congTyCtrl.LayIDThongTinCT();
                        congTyInfo.TenCongTy = txtTenCT.Text;
                        congTyInfo.DiaChi = txtDiaChi.Text;
                        congTyInfo.SDT = txtSDT.Text;
                        congTyInfo.Fax = txtFax.Text;
                        m_congTyCtrl.LuuThongTinCT_LanN(congTyInfo);
                    }
                    else
                    {
                        congTyInfo.ID = "CONGTY";
                        congTyInfo.TenCongTy = txtTenCT.Text;
                        congTyInfo.DiaChi = txtDiaChi.Text;
                        congTyInfo.SDT = txtSDT.Text;
                        congTyInfo.Fax = txtFax.Text;
                        m_congTyCtrl.LuuThongTinCT_Lan1(congTyInfo);
                    }
                    Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
                }
                catch
                {
                    Utilities.frmMain.lbThongBao.Text = "Lỗi.";
                }
            }
            else
                Utilities.frmMain.lbThongBao.Text = "Nhâp thiếu dữ liệu.";
        }
    }
}

