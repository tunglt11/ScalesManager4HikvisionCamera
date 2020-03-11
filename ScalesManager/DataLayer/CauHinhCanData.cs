using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{

    class CauHinhCanData
    {
        DataService m_CauHinhCanData = new DataService();

        public DataTable LayCauHinhCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CAUHINHCAN");
            m_CauHinhCanData.Load(cmd);
            return m_CauHinhCanData;
        }

        public DataTable LayIDCauHinhCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM CAUHINHCAN");
            m_CauHinhCanData.Load(cmd);
            return m_CauHinhCanData;
        }

        public DataRow ThemDongMoi()
        {
            return m_CauHinhCanData.NewRow();
        }

        public void ThemCauHinhCan(DataRow m_Row)
        {
            m_CauHinhCanData.Rows.Add(m_Row);
        }

        public bool LuuCauHinhCanLan1(CauHinhCanInfo cauHinhCanInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CAUHINHCAN VALUES" +
                "(@ID, " +
                "@COM, " +
                "@RAUDRATE, " +
                "@DATABITS, " +
                "@PARITY, " +
                "@STOPBIT, " +
                "@DATALENGHT, " +
                "@SFROM, " +
                "@STO, " +
                "@KiTuNgat)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhCanInfo.ID;
            cmd.Parameters.Add("COM", SqlDbType.VarChar).Value = cauHinhCanInfo.COM;
            cmd.Parameters.Add("RAUDRATE", SqlDbType.VarChar).Value = cauHinhCanInfo.RAUDRATE;
            cmd.Parameters.Add("DATABITS", SqlDbType.VarChar).Value = cauHinhCanInfo.DATABITS;
            cmd.Parameters.Add("PARITY", SqlDbType.VarChar).Value = cauHinhCanInfo.PARITY;
            cmd.Parameters.Add("STOPBIT", SqlDbType.VarChar).Value = cauHinhCanInfo.STOPBIT;
            cmd.Parameters.Add("DATALENGHT", SqlDbType.VarChar).Value = cauHinhCanInfo.DATALENGHT;
            cmd.Parameters.Add("SFROM", SqlDbType.VarChar).Value = cauHinhCanInfo.SFROM;
            cmd.Parameters.Add("STO", SqlDbType.VarChar).Value = cauHinhCanInfo.STO;
            cmd.Parameters.Add("KiTuNgat", SqlDbType.VarChar).Value = cauHinhCanInfo.KiTuNgat;
            m_CauHinhCanData.ExecuteNoneQuery(cmd);
            return true;
        }
        public bool LuuCauHinhCanLanN(CauHinhCanInfo cauHinhCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CAUHINHCAN " +
                "SET COM = @COM, " +
                "RAUDRATE = @RAUDRATE, " +
                "DATABITS = @DATABITS, " +
                "PARITY = @PARITY, " +
                "STOPBIT = @STOPBIT, " +
                 "DATALENGHT = @DATALENGHT, " +
                "SFROM = @SFROM, " +
                "STO = @STO, " +
                "KiTuNgat = @KiTuNgat" +
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = cauHinhCanInfo.ID;
            cmd.Parameters.Add("COM", SqlDbType.VarChar).Value = cauHinhCanInfo.COM;
            cmd.Parameters.Add("RAUDRATE", SqlDbType.VarChar).Value = cauHinhCanInfo.RAUDRATE;
            cmd.Parameters.Add("DATABITS", SqlDbType.VarChar).Value = cauHinhCanInfo.DATABITS;
            cmd.Parameters.Add("PARITY", SqlDbType.VarChar).Value = cauHinhCanInfo.PARITY;
            cmd.Parameters.Add("STOPBIT", SqlDbType.VarChar).Value = cauHinhCanInfo.STOPBIT;
            cmd.Parameters.Add("DATALENGHT", SqlDbType.VarChar).Value = cauHinhCanInfo.DATALENGHT;
            cmd.Parameters.Add("SFROM", SqlDbType.VarChar).Value = cauHinhCanInfo.SFROM;
            cmd.Parameters.Add("STO", SqlDbType.VarChar).Value = cauHinhCanInfo.STO;
            cmd.Parameters.Add("KiTuNgat", SqlDbType.VarChar).Value = cauHinhCanInfo.KiTuNgat;

            return m_CauHinhCanData.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
