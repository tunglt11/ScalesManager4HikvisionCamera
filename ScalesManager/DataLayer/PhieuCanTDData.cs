using ScalesManager.Bussiness;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ScalesManager.DataLayer
{
    class PhieuCanTDData
    {
        DataService _PhieuCanTDData = new DataService();

        public DataTable LayPhieuCan(string _id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCANTUDONG WHERE ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = _id;
            _PhieuCanTDData.Load(cmd);
            return _PhieuCanTDData;
        }

        public DataTable LayPhieuCan2(string _id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCANTUDONG WHERE ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = _id;
            _PhieuCanTDData.Load(cmd);
            return _PhieuCanTDData;
        }

        public DataTable LayDsPhieuCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCANTUDONG");
            _PhieuCanTDData.Load(cmd);
            return _PhieuCanTDData;
        }

        public DataTable LayDsPhieuCanTatCa(DateTime _NgayCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCANTUDONG WHERE" +
                " NgayGio BETWEEN @beginDate AND @endDate " +
                " ORDER BY NgayGio DESC");
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value = endDate;
            _PhieuCanTDData.Load(cmd);
            return _PhieuCanTDData;
        }

        public DataRow ThemDongMoi()
        {
            return _PhieuCanTDData.NewRow();
        }

        public void ThemPhieuCan(DataRow m_Row)
        {
            _PhieuCanTDData.Rows.Add(m_Row);
        }

        public bool LuuPhieuCan()
        {
            return _PhieuCanTDData.ExecuteNoneQuery() > 0;
        }
        public bool LuuCanlan1(PhieuCanTDInfo phieuCanTDInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PHIEUCANTUDONG VALUES" +
                "(@ID, " +
                "@KLXe, " +
                "@NgayGio)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = phieuCanTDInfo.ID;
            cmd.Parameters.Add("KLXe", SqlDbType.Decimal).Value = phieuCanTDInfo.KLXe;
            cmd.Parameters.Add("NgayGio", SqlDbType.DateTime).Value = phieuCanTDInfo.NgayGio;
            _PhieuCanTDData.ExecuteNoneQuery(cmd);
            return true;
        }
        public bool XoaPhieuCan(PhieuCanTDInfo phieuCanTDInfo)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PHIEUCANTUDONG " +
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = phieuCanTDInfo.ID;

            return _PhieuCanTDData.ExecuteNoneQuery(cmd) > 0;
        }     
        public DataTable InPhieuCan(string id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCANTUDONG Where ID ='" + id + "'");
            _PhieuCanTDData.Load(cmd);
            return _PhieuCanTDData;
        }
    }
}
