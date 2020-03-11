using ScalesManager.Bussiness;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

namespace ScalesManager.DataLayer
{
    public class PhieuCanData
    {
        DataService _PhieuCanData = new DataService();

        public DataTable LayPhieuCan(string _maphieu)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCAN WHERE MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = _maphieu;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }

        public DataTable LayPhieuCanTheoBSX(string bsx)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCAN WHERE BSX = @BSX AND (KLCanLan1*KLCanLan2 = 0) ORDER BY MaPhieu DESC");
            cmd.Parameters.Add("BSX", SqlDbType.VarChar).Value = bsx;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }

        public DataTable LayPhieuCan2(string _maphieu)
        {
            SqlCommand cmd = new SqlCommand("SELECT MaPhieu, BSX, LaiXe, KhachHang, LoaiHang, KLCanLan1, KLCanLan2, DonGia, CheDoCan, KieuCanLan1, KieuCanLan2, TenNhanVienCanLan1, TenNhanVienCanLan2, NgayCanLan1, NgayCanLan2, BienSoXe, BienSoXeRa FROM PHIEUCAN WHERE MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = _maphieu;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }

        public DataTable LayPhieuCan3(string _maphieu)
        {
            SqlCommand cmd = new SqlCommand("SELECT Cam1, Cam2, Cam3 FROM PHIEUCAN WHERE MaPhieu = @MaPhieu ");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = _maphieu;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }

        public DataTable LayDsPhieuCan()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCAN");
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }

        public DataTable LayDsPhieuCanTatCa(DateTime _NgayCan, String bsx, String chedoCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT MaPhieu, BSX, LaiXe, KhachHang, LoaiHang, KLCanLan1, KLCanLan2, KLCanLan1 - KLCanLan2 as Khoiluong, DonGia, CheDoCan, KieuCanLan1, KieuCanLan2, TenNhanVienCanLan1, TenNhanVienCanLan2, NgayCanLan1, NgayCanLan2 FROM PHIEUCAN WHERE" +
                " (NgayCanLan1 BETWEEN @beginDate AND @endDate OR NgayCanLan2 BETWEEN @beginDate AND @endDate)" +
                " AND BSX like @bsx" +
                " AND CheDoCan = @chedoCan ORDER BY MaPhieu DESC");
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value = endDate;
            cmd.Parameters.Add("bsx", SqlDbType.VarChar).Value = "%" + bsx + "%";
            cmd.Parameters.Add("chedoCan", SqlDbType.NVarChar).Value = chedoCan;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }
        public DataTable LayDsPhieuCanLan2(DateTime _NgayCan, String bsx, String chedoCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT MaPhieu, BSX, LaiXe, KhachHang, LoaiHang, KLCanLan1, KLCanLan2, KLCanLan1 - KLCanLan2 as Khoiluong, DonGia, CheDoCan, KieuCanLan1, KieuCanLan2, TenNhanVienCanLan1, TenNhanVienCanLan2, NgayCanLan1, NgayCanLan2 FROM PHIEUCAN WHERE" +
                " NgayCanLan2 BETWEEN @beginDate AND @endDate " +
                " AND BSX like @bsx" +
                 " AND NgayCanLan2 IS NOT NULL" +
                " AND CheDoCan = @chedoCan ORDER BY NgayCanLan2 DESC");
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value = endDate;
            cmd.Parameters.Add("bsx", SqlDbType.VarChar).Value = "%" + bsx + "%";
            cmd.Parameters.Add("chedoCan", SqlDbType.NVarChar).Value = chedoCan;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }
        public DataTable LayDsPhieuChuaCanLan2(DateTime _NgayCan, String bsx, String chedoCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT MaPhieu, BSX, LaiXe, KhachHang, LoaiHang, KLCanLan1, KLCanLan2, KLCanLan1 - KLCanLan2 as Khoiluong, DonGia, CheDoCan, KieuCanLan1, KieuCanLan2, TenNhanVienCanLan1, TenNhanVienCanLan2, NgayCanLan1, NgayCanLan2 FROM PHIEUCAN WHERE" +
                " NgayCanLan2 IS NULL " +
                " AND NgayCanLan1 BETWEEN @beginDate AND @endDate " +
                " AND BSX like @bsx" + 
                " AND NgayCanLan2 IS NULL" +
                " AND CheDoCan = @chedoCan ORDER BY NgayCanLan1 DESC");
            cmd.Parameters.Add("ngaycan", SqlDbType.VarChar).Value = _NgayCan;
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value = endDate;
            cmd.Parameters.Add("bsx", SqlDbType.VarChar).Value = "%"+bsx+"%";
            cmd.Parameters.Add("chedoCan", SqlDbType.NVarChar).Value = chedoCan;
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }
        public int demSoPhieuTrongNgay(DateTime _NgayCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM PHIEUCAN WHERE (NgayCanLan1 BETWEEN @beginDate AND @endDate) OR (NgayCanLan2 BETWEEN @beginDate AND @endDate)");
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value   = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value     = endDate;
            return (int)_PhieuCanData.ExecuteScalar(cmd);
        }

        public int demSoPhieuLan2TrongNgay(DateTime _NgayCan)
        {
            DateTime beginDate = _NgayCan.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
            DateTime endDate = _NgayCan.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM PHIEUCAN WHERE NgayCanLan1 BETWEEN @beginDate AND @endDate AND NgayCanLan2 BETWEEN @beginDate AND @endDate");
            cmd.Parameters.Add("beginDate", SqlDbType.DateTime).Value = beginDate;
            cmd.Parameters.Add("endDate", SqlDbType.DateTime).Value = endDate;
            return (int)_PhieuCanData.ExecuteScalar(cmd);
        }

        public DataRow ThemDongMoi()
        {
            return _PhieuCanData.NewRow();
        }

        public void ThemPhieuCan(DataRow m_Row)
        {
            _PhieuCanData.Rows.Add(m_Row);
        }

        public bool LuuPhieuCan()
        {
            return _PhieuCanData.ExecuteNoneQuery() > 0;
        }

        public bool CapNhatPhieuCan(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET KhachHang = @KhachHang, " +
                "LaiXe = @LaiXe, " +
                "BSX = @BSX, " +
                "KLCanLan1 = @KLCanLan1, " +
                "KLCanLan2 = @KLCanLan2 " +           
                "where MaPhieu = @MaPhieu");

            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
            cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
            cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
            cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
            cmd.Parameters.Add("BSX", SqlDbType.NVarChar).Value = phieuCanInfo.BSX;

            _PhieuCanData.ExecuteNoneQuery(cmd);

            return true;
        }

        public bool LuuPhieuCanTuDong(PhieuCanInfo phieuCanInfo)
        {
            var connetionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["ScalesManager.Properties.Settings.SCALES_MANAGER_DBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                SqlCommand cmd;
                // neu phieu can da co
                if (LayPhieuCan(phieuCanInfo.MaPhieu).Rows.Count > 0)
                {
                    cmd = new SqlCommand("UPDATE PHIEUCAN " +
                    "SET KLCanLan1 = @KLCanLan1, " +
                    "KLCanLan2 = @KLCanLan2, " +
                    "NgayCanLan1 = @NgayCanLan1, " +
                    "NgayCanLan2 = @NgayCanLan2, " +
                    "BienSoXeRa = @BienSoXeRa" +
                    " where MaPhieu = @MaPhieu", connection);

                    cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
                    cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
                    cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
                    cmd.Parameters.Add("NgayCanLan1", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan1;
                    cmd.Parameters.Add("NgayCanLan2", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan2;
                    if (phieuCanInfo.BienSoXeRa == null)
                        cmd.Parameters.Add("BienSoXeRa", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.BienSoXeRa.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("BienSoXeRa", SqlDbType.Image).Value = ms.ToArray();
                        }
                }
                else // neu can lan dau
                {
                    cmd = new SqlCommand("INSERT INTO PHIEUCAN VALUES" +
                    "(@ID, " +
                    "@MaPhieu, " +
                    "@BSX, " +
                    "@KhachHang, " +
                    "@LoaiHang, " +
                    "@KLCanLan1, " +
                    "@KLCanLan2, " +
                    "@KieuCanLan1, " +
                    "@KieuCanLan2, " +
                    "@NgayCanLan1, " +
                    "@NgayCanLan2, " +
                    "@TenNhanVienCanLan1, " +
                    "@TenNhanVienCanLan2, " +
                    "@MaNhanVienCanLan1, " +
                    "@MaNhanVienCanLan2, " +
                    "@LaiXe, " +
                    "@DonGia, " +
                    "@LanIn, " +
                    "@CheDoCan, " +
                    "@Cam1, " +
                    "@Cam2, " +
                    "@Cam3, " +
                    "@BienSoXe, " +
                    "@BienSoXeRa)", connection);

                    cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = phieuCanInfo.ID;
                    cmd.Parameters.Add("MaPhieu", SqlDbType.NVarChar).Value = phieuCanInfo.MaPhieu;
                    cmd.Parameters.Add("BSX", SqlDbType.NVarChar).Value = phieuCanInfo.BSX;
                    cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
                    cmd.Parameters.Add("LoaiHang", SqlDbType.NVarChar).Value = phieuCanInfo.LoaiHang;
                    cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
                    cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
                    cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan1;
                    cmd.Parameters.Add("KieuCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
                    cmd.Parameters.Add("NgayCanLan1", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan1;
                    cmd.Parameters.Add("NgayCanLan2", SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add("TenNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan1;
                    cmd.Parameters.Add("MaNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan1;
                    if (string.IsNullOrEmpty(phieuCanInfo.TenNhanVienCanLan2))
                        cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan2;
                    if (string.IsNullOrEmpty(phieuCanInfo.MaNhanVienCanLan2))
                        cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan2;
                    cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
                    cmd.Parameters.Add("DonGia", SqlDbType.Decimal).Value = phieuCanInfo.DonGia;
                    cmd.Parameters.Add("LanIn", SqlDbType.Decimal).Value = phieuCanInfo.LanIn;
                    cmd.Parameters.Add("CheDoCan", SqlDbType.NVarChar).Value = phieuCanInfo.ChedoCan;

                    if (phieuCanInfo.Cam1 == null)
                        cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.Cam1.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = ms.ToArray();
                        }

                    if (phieuCanInfo.Cam2 == null)
                        cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.Cam2.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = ms.ToArray();
                        }

                    if (phieuCanInfo.Cam3 == null)
                        cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.Cam3.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = ms.ToArray();
                        }

                    if (phieuCanInfo.BienSoXe == null)
                        cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.BienSoXe.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = ms.ToArray();
                        }

                    if (phieuCanInfo.BienSoXeRa == null)
                        cmd.Parameters.Add("BienSoXeRa", SqlDbType.Image).Value = DBNull.Value;
                    else
                        using (MemoryStream ms = new MemoryStream())
                        {
                            phieuCanInfo.BienSoXeRa.Save(ms, ImageFormat.Jpeg);
                            cmd.Parameters.Add("BienSoXeRa", SqlDbType.Image).Value = ms.ToArray();
                        }
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }

            //_PhieuCanData.ExecuteNoneQuery(cmd);

            return true;
        }
        public bool LuuCanlan1(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PHIEUCAN VALUES" +
                "(@ID, " +
                "@MaPhieu, " +
                "@BSX, " +
                "@KhachHang, " +
                "@LoaiHang, " +
                "@KLCanLan1, " +
                "@KLCanLan2, " +
                "@KieuCanLan1, " +
                "@KieuCanLan2, " +
                "@NgayCanLan1, " +
                "@NgayCanLan2, " +
                "@TenNhanVienCanLan1, " +
                "@TenNhanVienCanLan2, " +
                "@MaNhanVienCanLan1, " +
                "@MaNhanVienCanLan2, " +
                "@LaiXe, " +                
                "@DonGia, " +
                "@LanIn, " + 
                "@CheDoCan, " +
                "@Cam1, " +
                "@Cam2, " +
                "@Cam3, " +
                "@BienSoXe)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = phieuCanInfo.ID;
            cmd.Parameters.Add("MaPhieu", SqlDbType.NVarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("BSX", SqlDbType.NVarChar).Value = phieuCanInfo.BSX;
            cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
            cmd.Parameters.Add("LoaiHang", SqlDbType.NVarChar).Value = phieuCanInfo.LoaiHang;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
            cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
            cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan1;
            cmd.Parameters.Add("KieuCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("NgayCanLan1", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan1;
            cmd.Parameters.Add("NgayCanLan2", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("TenNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan1;
            cmd.Parameters.Add("MaNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan1;
            if (string.IsNullOrEmpty(phieuCanInfo.TenNhanVienCanLan2))
                cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan2;            
            if (string.IsNullOrEmpty(phieuCanInfo.MaNhanVienCanLan2))
                cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan2;
            cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
            cmd.Parameters.Add("DonGia", SqlDbType.Decimal).Value = phieuCanInfo.DonGia;
            cmd.Parameters.Add("LanIn", SqlDbType.Decimal).Value = phieuCanInfo.LanIn;
            cmd.Parameters.Add("CheDoCan", SqlDbType.NVarChar).Value = phieuCanInfo.ChedoCan;

            if (phieuCanInfo.Cam1 == null)
                cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = DBNull.Value;
            else            
                using(MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam1.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = ms.ToArray();
                }                

            if (phieuCanInfo.Cam2 == null)
                cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam2.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = ms.ToArray();
                }

            if (phieuCanInfo.Cam3 == null)
                cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam3.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = ms.ToArray();
                }

            if (phieuCanInfo.BienSoXe == null)
                cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.BienSoXe.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = ms.ToArray();
                }

            _PhieuCanData.ExecuteNoneQuery(cmd);
            return  true;
        }
        public bool LuuCanlan2(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET KLCanLan2 = @KLCanLan2, " +              
                "KieuCanLan2 = @KieuCanLan2, " +
                "NgayCanLan2 = @NgayCanLan2, " +
                "TenNhanVienCanLan2 = @TenNhanVienCanLan2, " +
                "MaNhanVienCanLan2 = @MaNhanVienCanLan2 " +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;      
            cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
            cmd.Parameters.Add("KieuCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan2;            
            cmd.Parameters.Add("NgayCanLan2", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan2;
            cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan2;           
            cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan2;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool LuuCanBi(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET KLCanLan1 = @KLCanLan1, " +
                "KieuCanLan1 = @KieuCanLan1, " +
                "NgayCanLan1 = @NgayCanLan1, " +
                "TenNhanVienCanLan1 = @TenNhanVienCanLan1, " +
                "MaNhanVienCanLan1 = @MaNhanVienCanLan1 " +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
            cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan1;
            cmd.Parameters.Add("NgayCanLan1", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan1;
            cmd.Parameters.Add("TenNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan1;
            cmd.Parameters.Add("MaNhanVienCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan1;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool LuuCanTong(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PHIEUCAN VALUES" +
                "(@ID, " +
                "@MaPhieu, " +
                "@BSX, " +
                "@KhachHang, " +
                "@LoaiHang, " +
                "@KLCanLan1, " +
                "@KLCanLan2, " +
                "@KieuCanLan1, " +
                "@KieuCanLan2, " +
                "@NgayCanLan1, " +
                "@NgayCanLan2, " +
                "@TenNhanVienCanLan1, " +
                "@TenNhanVienCanLan2, " +
                "@MaNhanVienCanLan1, " +
                "@MaNhanVienCanLan2, " +
                "@LaiXe, " +
                "@DonGia, " +
                "@LanIn, " +
                "@CheDoCan, " +
                "@Cam1, " +
                "@Cam2, " +
                "@Cam3, " +
                "@BienSoXe)");

            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = phieuCanInfo.ID;
            cmd.Parameters.Add("MaPhieu", SqlDbType.NVarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("BSX", SqlDbType.NVarChar).Value = phieuCanInfo.BSX;
            cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
            cmd.Parameters.Add("LoaiHang", SqlDbType.NVarChar).Value = phieuCanInfo.LoaiHang;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = DBNull.Value;
            cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
            cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("KieuCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan2;
            cmd.Parameters.Add("NgayCanLan1", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("NgayCanLan2", SqlDbType.DateTime).Value = phieuCanInfo.NgayCanLan2;
            cmd.Parameters.Add("TenNhanVienCanLan1", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("TenNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.TenNhanVienCanLan2;
            cmd.Parameters.Add("MaNhanVienCanLan1", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("MaNhanVienCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.MaNhanVienCanLan2;
            cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
            cmd.Parameters.Add("DonGia", SqlDbType.Decimal).Value = phieuCanInfo.DonGia;
            cmd.Parameters.Add("LanIn", SqlDbType.Decimal).Value = phieuCanInfo.LanIn;
            cmd.Parameters.Add("CheDoCan", SqlDbType.NVarChar).Value = phieuCanInfo.ChedoCan;

            if (phieuCanInfo.Cam1 == null)
                cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam1.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam1", SqlDbType.Image).Value = ms.ToArray();
                }

            if (phieuCanInfo.Cam2 == null)
                cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam2.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam2", SqlDbType.Image).Value = ms.ToArray();
                }

            if (phieuCanInfo.Cam3 == null)
                cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.Cam3.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("Cam3", SqlDbType.Image).Value = ms.ToArray();
                }

            if (phieuCanInfo.BienSoXe == null)
                cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = DBNull.Value;
            else
                using (MemoryStream ms = new MemoryStream())
                {
                    phieuCanInfo.BienSoXe.Save(ms, ImageFormat.Jpeg);
                    cmd.Parameters.Add("BienSoXe", SqlDbType.Image).Value = ms.ToArray();
                }
            
            _PhieuCanData.ExecuteNoneQuery(cmd);
            return true;
        }

        public bool SuaCanlan1(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET BSX = @BSX, " +
                "KhachHang = @KhachHang, " +
                "LoaiHang = @LoaiHang, " +
                "KLCanLan1 = @KLCanLan1, " +
                "KieuCanLan1 = @KieuCanLan1, " +
                "LaiXe = @LaiXe, " +
                "DonGia = @DonGia" +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("BSX", SqlDbType.VarChar).Value = phieuCanInfo.BSX;
            cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
            cmd.Parameters.Add("LoaiHang", SqlDbType.NVarChar).Value = phieuCanInfo.LoaiHang;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
            cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan1;
            cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
            cmd.Parameters.Add("DonGia", SqlDbType.Decimal).Value = phieuCanInfo.DonGia;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool SuaCanlan2(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET BSX = @BSX, " +
                "KhachHang = @KhachHang, " +
                "LoaiHang = @LoaiHang, " +
                "KLCanLan1 = @KLCanLan1, " +
                "KLCanLan2 = @KLCanLan2, " +
                "KieuCanLan1 = @KieuCanLan1, " +
                "KieuCanLan2 = @KieuCanLan2, " +
                "LaiXe = @LaiXe, " +
                "DonGia = @DonGia" +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("BSX", SqlDbType.VarChar).Value = phieuCanInfo.BSX;
            cmd.Parameters.Add("KhachHang", SqlDbType.NVarChar).Value = phieuCanInfo.KhachHang;
            cmd.Parameters.Add("LoaiHang", SqlDbType.NVarChar).Value = phieuCanInfo.LoaiHang;
            cmd.Parameters.Add("KLCanLan1", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan1;
            cmd.Parameters.Add("KLCanLan2", SqlDbType.Decimal).Value = phieuCanInfo.KLCanLan2;
            cmd.Parameters.Add("KieuCanLan1", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan1;
            cmd.Parameters.Add("KieuCanLan2", SqlDbType.NVarChar).Value = phieuCanInfo.KieuCanLan2;
            cmd.Parameters.Add("LaiXe", SqlDbType.NVarChar).Value = phieuCanInfo.LaiXe;
            cmd.Parameters.Add("DonGia", SqlDbType.Decimal).Value = phieuCanInfo.DonGia;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool XoaPhieuCan(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PHIEUCAN " +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool XoaPhieuCan(string maphieu)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PHIEUCAN " +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = maphieu;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public bool LuuLanIn(PhieuCanInfo phieuCanInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PHIEUCAN " +
                "SET LanIn = @LanIn" +
                " where MaPhieu = @MaPhieu");
            cmd.Parameters.Add("MaPhieu", SqlDbType.VarChar).Value = phieuCanInfo.MaPhieu;
            cmd.Parameters.Add("LanIn", SqlDbType.Decimal).Value = phieuCanInfo.LanIn;

            return _PhieuCanData.ExecuteNoneQuery(cmd) > 0;
        }

        public DataTable InPhieuCan(string maphieu)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PHIEUCAN Where MaPhieu ='" + maphieu + "'");
            _PhieuCanData.Load(cmd);
            return _PhieuCanData;
        }
    }
}
