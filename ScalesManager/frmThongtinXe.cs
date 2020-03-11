using DevComponents.DotNetBar;
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Component;

namespace ScalesManager
{
    public partial class frmThongtinXe : Office2007Form
    {
        #region Fields        
        XeCtrl m_XeCtrl = new XeCtrl();

        #endregion

        #region Constructor
        public frmThongtinXe()
        {
            InitializeComponent();
            DataService.OpenConnection();
        }
        #endregion

        #region Load
        private void frmThongtinXe_Load(object sender, EventArgs e)
        {
            m_XeCtrl.HienThi(dGVXe, bindingNavigatorXe);
        }

        #endregion

        #region BindingNavigatorItems
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVXe.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;

            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorXe.BindingSource.RemoveCurrent();
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (dGVXe.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = true;

            DataRow m_Row = m_XeCtrl.ThemDongMoi();
            m_Row["MaXe"] = "Xe-" + dGVXe.Rows.Count + 1;
            m_Row["BSX"] = "";
            m_Row["TrongLuong"] = 0;
            m_Row["TaiXe"] = "";
            m_Row["KhachHang"] = "";
            m_Row["LoaiXe"] = "";
            m_XeCtrl.ThemXe(m_Row);
            bindingNavigatorXe.BindingSource.MoveLast();
        }

        public Boolean KiemTraTruocKhiLuu(String cellString)
        {
            foreach (DataGridViewRow row in dGVXe.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    String str = row.Cells[cellString].Value.ToString();
                    if (str == "")
                    {
                        MessageBoxEx.Show("Thông tin xe không hợp lệ!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiLuu("colBSX") && KiemTraTruocKhiLuu("colTrongLuong"))
            {
                bindingNavigatorPositionItem.Focus();
                m_XeCtrl.LuuXe();
            }
        }

        #endregion

        #region DataError event
        private void dGVKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

    }
}
