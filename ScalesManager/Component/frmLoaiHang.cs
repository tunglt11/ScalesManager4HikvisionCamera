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
    public partial class frmLoaiHang : Form
    {
        #region Fields
        LoaiHangCtrl m_LoaiHangCtrl = new LoaiHangCtrl();
        #endregion

        #region Constructor
        public frmLoaiHang()
        {
                InitializeComponent();
                DataService.OpenConnection();
        }
        #endregion

        private void bindingNavigatorLoaiHang_RefreshItems(object sender, EventArgs e)
        {

        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            m_LoaiHangCtrl.HienThi(dGVLoaiHang, bindingNavigatorLoaiHang);
        }

        #region BindingNavigatorItems
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVLoaiHang.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;

            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorLoaiHang.BindingSource.RemoveCurrent();
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (dGVLoaiHang.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = true;

            DataRow m_Row = m_LoaiHangCtrl.ThemDongMoi();
            m_Row["ID"] = "LH" + dGVLoaiHang.Rows.Count + 1;
            m_Row["LoaiHang"] = "";
            m_Row["DonGia"] = 0;
            m_LoaiHangCtrl.ThemLoaiHang(m_Row);
            bindingNavigatorLoaiHang.BindingSource.MoveLast();
        }

        public Boolean KiemTraTruocKhiLuu(String cellString)
        {
            foreach (DataGridViewRow row in dGVLoaiHang.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    String str = row.Cells[cellString].Value.ToString();
                    if (str == "")
                    {
                        MessageBoxEx.Show("Thông tin hàng không hợp lệ!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiLuu("colID") == true &&
               KiemTraTruocKhiLuu("colLoaiHang") == true &&
               KiemTraTruocKhiLuu("colDonGia") == true)
            {
                bindingNavigatorPositionItem.Focus();
                m_LoaiHangCtrl.LuuLoaiHang();
                Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
            }
        }
        #endregion

        #region DataError event
        private void dGVLoaiHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion
    }
}
