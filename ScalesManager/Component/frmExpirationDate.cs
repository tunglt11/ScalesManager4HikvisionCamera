using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ScalesManager.Component;
using ScalesManager.Bussiness;
using ScalesManager.Controller;

namespace ScalesManager.Component
{
    public partial class frmExpirationDate : Office2007Form
    {
        KeysInfo m_keyInfo = new KeysInfo();
        KeysCtrl m_keysCtrl = new KeysCtrl();

        public frmExpirationDate()
        {
            InitializeComponent();
        }

        private void frmExpirationDate_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmExpirationDate_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtKeys.Text == "")
                lbThongBao.Text = "Chưa nhập mã kích hoạt.";
            else if(txtKeys.Text != m_keysCtrl.LayKey().Keys)
            {
                lbThongBao.Text = "Sai mã kích hoạt.";
            }
            else
            {
                m_keyInfo.ID = m_keysCtrl.LayKey().ID;
                m_keyInfo.StartDate = m_keysCtrl.LayKey().StartDate.AddYears(500);
                m_keysCtrl.LuuKeys(m_keyInfo);
                this.Close();
            }
        }

        private void frmExpirationDate_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
