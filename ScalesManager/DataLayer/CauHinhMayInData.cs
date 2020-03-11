using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{
    class CauHinhMayInData
    {
        DataService m_CauHinhMayInData = new DataService();

        public DataTable LayCauHinhMayIn()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CAUHINHIN");
            m_CauHinhMayInData.Load(cmd);
            return m_CauHinhMayInData;
        }

        public DataTable LayIDCauHinhMayIn()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM CAUHINHIN");
            m_CauHinhMayInData.Load(cmd);
            return m_CauHinhMayInData;
        }

        public DataRow ThemDongMoi()
        {
            return m_CauHinhMayInData.NewRow();
        }

        public void ThemCauHinhMayIn(DataRow m_Row)
        {
            m_CauHinhMayInData.Rows.Add(m_Row);
        }

        public bool LuuCauHinhMayInLan1(CauHinhMayInInfo cauHinhMayInInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CAUHINHIN VALUES" +
                "(@ID, " +
                "@TenMayIn, " +
                "@SoPhieu)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhMayInInfo.ID;
            cmd.Parameters.Add("TenMayIn", SqlDbType.VarChar).Value = cauHinhMayInInfo.TenMayIn;
            cmd.Parameters.Add("SoPhieu", SqlDbType.VarChar).Value = cauHinhMayInInfo.SoPhieu;
            m_CauHinhMayInData.ExecuteNoneQuery(cmd);
            return true;
        }
        public bool LuuCauHinhMayInLanN(CauHinhMayInInfo cauHinhMayInInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CAUHINHIN " +
                "SET TenMayIn = @TenMayIn, " +
                "SoPhieu = @SoPhieu" +                
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhMayInInfo.ID;
            cmd.Parameters.Add("TenMayIn", SqlDbType.VarChar).Value = cauHinhMayInInfo.TenMayIn;
            cmd.Parameters.Add("SoPhieu", SqlDbType.VarChar).Value = cauHinhMayInInfo.SoPhieu;

            return m_CauHinhMayInData.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
