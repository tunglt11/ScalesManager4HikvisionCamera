using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using ScalesManager.DataLayer;
using ScalesManager.Component;
using ScalesManager.Bussiness;

namespace ScalesManager.Controller
{
    class KhachHangCtrl
    {
        KhachHangData m_KhachHangData = new KhachHangData();
        KhachHangInfo m_KhachHangInfo = new KhachHangInfo();

        #region Do du lieu vao Gridview
        public void HienThi(DataGridView dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();

            bS.DataSource = m_KhachHangData.LayDSKhachHang();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        #endregion

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_KhachHangData.ThemDongMoi();
        }

        public void ThemNguoiDung(DataRow m_Row)
        {
            m_KhachHangData.ThemKhachHang(m_Row);
        }
        #endregion

        #region Luu du lieu
        public bool LuuNguoiDung()
        {
            return m_KhachHangData.LuuKhachHang();
        }
        #endregion

        #region Hien thi autocomplete

        public void HienThiAutoComplete(AutoCompleteStringCollection autoCompleteStringCollection, String strTimKiem)
        {
            foreach (DataRow row in m_KhachHangData.LayTenKhachHang(strTimKiem).Rows)
            {
                autoCompleteStringCollection.Add(row[0].ToString());
            }
        }
        #endregion
    }
}
