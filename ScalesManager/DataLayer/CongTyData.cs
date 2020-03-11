using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{

    class CongTyData
    {
        DataService m_CongTyData = new DataService();
        public DataTable LayThongTinCT()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CONGTY");
            m_CongTyData.Load(cmd);
            return m_CongTyData;
        }

        public DataTable LayIDCongTy()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM CONGTY");
            m_CongTyData.Load(cmd);
            return m_CongTyData;
        }

        public DataRow ThemDongMoi()
        {
            return m_CongTyData.NewRow();
        }

        public void ThemThongTinCT(DataRow m_Row)
        {
            m_CongTyData.Rows.Add(m_Row);
        }

        public bool LuuThongTinCTLan1(CongTyInfo congTyInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CONGTY VALUES" +
                "(@ID, " +
                "@TenCongTy, " +
                "@DiaChi, " +
                "@SDT, " +
                "@Fax)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = congTyInfo.ID;
            cmd.Parameters.Add("TenCongTy", SqlDbType.NVarChar).Value = congTyInfo.TenCongTy;
            cmd.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = congTyInfo.DiaChi;
            cmd.Parameters.Add("SDT", SqlDbType.VarChar).Value = congTyInfo.SDT;
            cmd.Parameters.Add("Fax", SqlDbType.VarChar).Value = congTyInfo.Fax;
            m_CongTyData.ExecuteNoneQuery(cmd);
            return true;
        }
        public bool LuuThongTinCTLanN(CongTyInfo congTyInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CONGTY " +
                "SET TenCongTy = @TenCongTy, " +
                "DiaChi = @DiaChi, " +
                "SDT = @SDT, " +
                "Fax = @Fax" +
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = congTyInfo.ID;
            cmd.Parameters.Add("TenCongTy", SqlDbType.NVarChar).Value = congTyInfo.TenCongTy;
            cmd.Parameters.Add("DiaChi", SqlDbType.NVarChar).Value = congTyInfo.DiaChi;
            cmd.Parameters.Add("SDT", SqlDbType.VarChar).Value = congTyInfo.SDT;
            cmd.Parameters.Add("Fax", SqlDbType.VarChar).Value = congTyInfo.Fax;

            return m_CongTyData.ExecuteNoneQuery(cmd) > 0;
        }
    }
}

