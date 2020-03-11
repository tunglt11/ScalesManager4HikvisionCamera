using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{
    class LoaiHangData
    {
        DataService m_LoaiHangData = new DataService();
        public DataTable LayDSLoaiHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM LOAIHANG");
            m_LoaiHangData.Load(cmd);
            return m_LoaiHangData;
        }

        public DataTable LayIDLoaiHang()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM LOAIHANG");
            m_LoaiHangData.Load(cmd);
            return m_LoaiHangData;
        }

        public DataRow ThemDongMoi()
        {
            return m_LoaiHangData.NewRow();
        }

        public void ThemLoaiHang(DataRow m_Row)
        {
            m_LoaiHangData.Rows.Add(m_Row);
        }

        public bool LuuLoaiHang()
        {
            return m_LoaiHangData.ExecuteNoneQuery() > 0;
        }
        
    }
}
