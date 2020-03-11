using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ScalesManager.Component
{
    public partial class frmTapChat : Office2007Form
    {
        public frmTapChat()
        {
            InitializeComponent();
        }

        private void frmTapChat_Load(object sender, EventArgs e)
        {

        }

        private void txtTapChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTapChat.Text != "")
            {
                Utilities.TapChat = decimal.Parse(txtTapChat.Text);
                this.Close();
            }
            else
            {
                label1.Text = "Chưa nhập khối lượng";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
