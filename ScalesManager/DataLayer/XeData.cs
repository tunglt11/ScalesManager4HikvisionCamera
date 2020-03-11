using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{
    class XeData
    {
        DataService m_XeData = new DataService();

        public DataTable LayDSXe()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM XE");
            m_XeData.Load(cmd);
            return m_XeData;
        }

        public DataTable LayXeTheoBSX(string strTimKiem)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM XE where BSX like '%" + strTimKiem +"%'");
            m_XeData.Load(cmd);
            return m_XeData;
        }

        public DataTable LayThongtinXe(string bsx)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM XE WHERE BSX = @BSX");
            cmd.Parameters.Add("BSX", SqlDbType.VarChar).Value = bsx;
            m_XeData.Load(cmd);
            return m_XeData;
        }

        public DataTable LayTenKhachHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT TenKH FROM KHACHHANG");
            m_XeData.Load(cmd);
            return m_XeData;
        }

        public DataRow ThemDongMoi()
        {
            return m_XeData.NewRow();
        }

        public void ThemKhachHang(DataRow m_Row)
        {
            m_XeData.Rows.Add(m_Row);
        }

        public bool LuuXe()
        {
            return m_XeData.ExecuteNoneQuery() > 0;
        }
    }
}
