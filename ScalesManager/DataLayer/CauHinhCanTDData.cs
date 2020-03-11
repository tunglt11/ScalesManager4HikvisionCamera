using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ScalesManager.Bussiness;
using System.Data;

namespace ScalesManager.DataLayer
{
    class CauHinhCanTDData
    {
        DataService m_CauHinhCanTDData = new DataService();

        public DataTable LayCauHinhCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CAUHINHCANTD");
            m_CauHinhCanTDData.Load(cmd);
            return m_CauHinhCanTDData;
        }

        public DataTable LayIDCauHinhCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM CAUHINHCANTD");
            m_CauHinhCanTDData.Load(cmd);
            return m_CauHinhCanTDData;
        }

        public DataRow ThemDongMoi()
        {
            return m_CauHinhCanTDData.NewRow();
        }

        public void ThemCauHinhCan(DataRow m_Row)
        {
            m_CauHinhCanTDData.Rows.Add(m_Row);
        }

        public bool LuuCauHinhCanLan1(CauHinhCanTDInfo cauHinhCanTDInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CAUHINHCANTD VALUES" +
                "(@ID, " +
                "@TimeSleep, " +
                "@KhoiLuong)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhCanTDInfo.ID;
            cmd.Parameters.Add("TimeSleep", SqlDbType.Int).Value = cauHinhCanTDInfo.TimeSleep;
            cmd.Parameters.Add("KhoiLuong", SqlDbType.Decimal).Value = cauHinhCanTDInfo.KhoiLuong;
            m_CauHinhCanTDData.ExecuteNoneQuery(cmd);
            return true;
        }
        public bool LuuCauHinhCanLanN(CauHinhCanTDInfo cauHinhCanTDInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CAUHINHCANTD " +
                "SET TimeSleep = @TimeSleep, " +
                "KhoiLuong = @KhoiLuong" +
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhCanTDInfo.ID;
            cmd.Parameters.Add("TimeSleep", SqlDbType.Int).Value = cauHinhCanTDInfo.TimeSleep;
            cmd.Parameters.Add("KhoiLuong", SqlDbType.Decimal).Value = cauHinhCanTDInfo.KhoiLuong;

            return m_CauHinhCanTDData.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
