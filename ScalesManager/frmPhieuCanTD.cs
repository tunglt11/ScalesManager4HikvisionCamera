using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ScalesManager.Controller;
using ScalesManager.Component;
using DevComponents.DotNetBar;
using ScalesManager.Bussiness;
using ScalesManager.Reports;
using System.IO.Ports;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace ScalesManager
{
    public partial class frmPhieuCanTD : Office2007Form
    {
        PhieuCanTDCtrl _PhieuCanTDCtrl = new PhieuCanTDCtrl();
        QuyDinh quyDinh = new QuyDinh();
        Random random = new Random();

        public frmPhieuCanTD()
        {
            InitializeComponent();
            dtpNgayCan.Value = DateTime.Now;
            DataService.OpenConnection();
        }

        private void groupBoxDanhSach_Enter(object sender, EventArgs e)
        {

        }

        private void frmPhieuCanTD_Load(object sender, EventArgs e)
        {
            hienThiPhieuCan();
        }
        public void hienThiPhieuCan()
        {
            DateTime ngayCan = dtpNgayCan.Value;
            if (ngayCan != null)
            {
                    _PhieuCanTDCtrl.HienThi(dGVPhieuCan, bindingNavigatorPhieuCan, ngayCan);
            }
            if (dGVPhieuCan.RowCount == 0)
            {
                btnXuatExcel.Enabled = false;
            }
            else
            {
                btnXuatExcel.Enabled = true;
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            hienThiPhieuCan();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dGVPhieuCan.RowCount == 0)
                bindingNavigatorDeleteItem.Enabled = false;

            else if (MessageBoxEx.Show("Bạn có chắc chắn xóa dòng này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigatorPhieuCan.BindingSource.RemoveCurrent();
            }
        }

        public Boolean KiemTraTruocKhiLuu(String cellString)
        {
            foreach (DataGridViewRow row in dGVPhieuCan.Rows)
            {
                if (row.Cells[cellString].Value != null)
                {
                    String str = row.Cells[cellString].Value.ToString();
                    if (str == "")
                    {
                        MessageBoxEx.Show("Thông tin không hợp lệ!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiLuu("KLXe") == true &&
               KiemTraTruocKhiLuu("NgayGio") == true)
            {
                bindingNavigatorPositionItem.Focus();
                _PhieuCanTDCtrl.LuuPhieuCan();
                Utilities.frmMain.lbThongBao.Text = "Lưu thành công.";
            }
        }

        private void dGVPhieuCan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                dGVPhieuCan.Rows[numrow].Cells[1].ReadOnly = true;
                dGVPhieuCan.Rows[numrow].Cells[2].ReadOnly = true;
            }
            catch
            {
                Utilities.frmMain.lbThongBao.Text = "Lỗi";
            }
        }
    }
}
