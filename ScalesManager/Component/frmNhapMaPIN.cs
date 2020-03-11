using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public partial class frmNhapMaPIN : Form
    {
        public frmNhapMaPIN()
        {
            InitializeComponent();
        }

        private void txtMaPIN_Enter(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMaPIN.Text != "" || txtMaPIN.Text != null)
                Utilities.MaPIN = txtMaPIN.Text;
            this.Close();
        }

        private void txtMaPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMaPIN.Text != "" || txtMaPIN.Text != null)
                    Utilities.MaPIN = txtMaPIN.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
