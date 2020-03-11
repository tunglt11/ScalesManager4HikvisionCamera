using System;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using ScalesManager.DataLayer;
using ScalesManager.Component;
using ScalesManager.Bussiness;

namespace ScalesManager.Controller
{
    class XeCtrl
    {
        XeData m_XeData = new XeData();
        XeInfo m_XeInfo = new XeInfo();


        #region Do du lieu vao Gridview
        public void HienThi(DataGridView dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();

            bS.DataSource = m_XeData.LayDSXe();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        #endregion

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_XeData.ThemDongMoi();
        }

        public void ThemXe(DataRow m_Row)
        {
            m_XeData.ThemKhachHang(m_Row);
        }
        #endregion

        #region Luu du lieu
        public bool LuuXe()
        {
            return m_XeData.LuuXe();
        }
        #endregion

        #region Hien thi autocomplete

        public void HienThiAutoComplete(AutoCompleteStringCollection autoCompleteStringCollection, String strTimKiem)
        {
            foreach (DataRow row in m_XeData.LayXeTheoBSX(strTimKiem).Rows)
            {
                autoCompleteStringCollection.Add(row[0].ToString());
            }
        }
        #endregion

        #region lấy thông tin xe
        public XeInfo LayThongTinXe(string bsx)
        {
            foreach (DataRow row in m_XeData.LayXeTheoBSX(bsx).Rows)
            {
                m_XeInfo.BSX = row["BSX"].ToString();
                m_XeInfo.TrongLuong = int.Parse(row["TrongLuong"].ToString());
                m_XeInfo.Khachhang = row["KhachHang"].ToString();
                m_XeInfo.TaiXe = row["TaiXe"].ToString();
                return m_XeInfo;
            }
            return null;
        }
        #endregion
    }
}