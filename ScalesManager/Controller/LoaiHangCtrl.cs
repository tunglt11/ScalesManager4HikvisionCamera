using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;

namespace ScalesManager.Controller
{
    class LoaiHangCtrl
    {
        LoaiHangData m_loaiHangData = new LoaiHangData();
        LoaiHangInfo m_loaiHangInffo = new LoaiHangInfo();

        #region Hien thi ComboBox
        public void HienThiComboBox(ComboBoxEx comboBox)
        {
            comboBox.DataSource = m_loaiHangData.LayDSLoaiHang();
            comboBox.DisplayMember = "LoaiHang";
            comboBox.ValueMember = "LoaiHang";
            
        }
        #endregion

        #region Do du lieu vao DataGridView
        public void HienThi(DataGridViewX dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();
            dGV.Columns["ColDonGia"].DefaultCellStyle.Format = "#,###";
            bS.DataSource = m_loaiHangData.LayDSLoaiHang();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        #endregion
        #region Hien thi ComboBox trong DataGridView
        public void HienThiDataGridViewComboBoxColumn(DataGridViewComboBoxColumn cmbColumn)
        {
            cmbColumn.DataSource = m_loaiHangData.LayDSLoaiHang();
            cmbColumn.DisplayMember = "LoaiHang";
            cmbColumn.ValueMember = "DonGia";
            cmbColumn.DataPropertyName = "LoaiHang";
            cmbColumn.HeaderText = "Loại hàng";
        }
        #endregion

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_loaiHangData.ThemDongMoi();
        }

        public void ThemLoaiHang(DataRow m_Row)
        {
            m_loaiHangData.ThemLoaiHang(m_Row);
        }
        #endregion

        #region Luu du lieu
        public bool LuuLoaiHang()
        {
            return m_loaiHangData.LuuLoaiHang();
        }
        #endregion

    }
}
