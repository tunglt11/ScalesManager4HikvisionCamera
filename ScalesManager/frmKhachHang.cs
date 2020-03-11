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
    public partial class frmKhachHang : Office2007Form
    {
        #region Fields
        KhachHangCtrl m_KhachHangCtrl = new KhachHangCtrl();
        #endregion

        #region Constructor
        public frmKhachHang()
        {
            InitializeComponent();
            DataService.OpenConnection();
        }
        #endregion

        #region Load
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            m_KhachHangCtrl.HienThi(dGVKhachHang, bindingNavigatorKhachHang);
        }

        #endregion

        #region BindingNavigatorItems
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVKhachHang.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;

            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorKhachHang.BindingSource.RemoveCurrent();
            }
        }

        private void bindingNavigatorExitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (dGVKhachHang.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = true;

            DataRow m_Row = m_KhachHangCtrl.ThemDongMoi();
            m_Row["MaKH"] = "KH" + dGVKhachHang.Rows.Count + 1;
            m_Row["TenKH"] = "";
            m_Row["SDT"] = "";
            m_Row["DiaChi"] = "";
            m_KhachHangCtrl.ThemNguoiDung(m_Row);
            bindingNavigatorKhachHang.BindingSource.MoveLast();
        }

        public Boolean KiemTraTruocKhiLuu(String cellString)
        {
            foreach (DataGridViewRow row in dGVKhachHang.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    String str = row.Cells[cellString].Value.ToString();
                    if (str == "")
                    {
                        MessageBoxEx.Show("Thông tin người dùng không hợp lệ!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiLuu("colMaKH") == true &&
                KiemTraTruocKhiLuu("colTenKH") == true &&
                KiemTraTruocKhiLuu("colSDT") == true &&
                KiemTraTruocKhiLuu("colDiaChi") == true)
            {
                bindingNavigatorPositionItem.Focus();
                m_KhachHangCtrl.LuuNguoiDung();
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
