using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ScalesManager.DataLayer
{
    class KhachHangData
    {
        DataService m_KhachHangData = new DataService();

        public DataTable LayDSKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM KHACHHANG");
            m_KhachHangData.Load(cmd);
            return m_KhachHangData;
        }

        public DataTable LayTenKhachHang(string strTimKiem)
        {
            SqlCommand cmd = new SqlCommand("SELECT TenKH FROM KHACHHANG where TenKH like '%" + strTimKiem +"%'");
            m_KhachHangData.Load(cmd);
            return m_KhachHangData;
        }

        public DataTable LayTenKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT TenKH FROM KHACHHANG");
            m_KhachHangData.Load(cmd);
            return m_KhachHangData;
        }

        public DataRow ThemDongMoi()
        {
            return m_KhachHangData.NewRow();
        }

        public void ThemKhachHang(DataRow m_Row)
        {
            m_KhachHangData.Rows.Add(m_Row);
        }

        public bool LuuKhachHang()
        {
            return m_KhachHangData.ExecuteNoneQuery() > 0;
        }
    }
}
