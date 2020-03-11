using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using ScalesManager.DataLayer;
using ScalesManager.Component;
using ScalesManager.Bussiness;
using System.Drawing;
using System.IO;

namespace ScalesManager.Controller
{
    public class PhieuCanCtrl
    {
        PhieuCanData _PhieuCanData = new PhieuCanData();
        PhieuCanInfo _PhieuCanInfo = new PhieuCanInfo();
        QuyDinh quyDinh = new QuyDinh();

        #region lấy phiếu cân
        public PhieuCanInfo LayPhieuCan(string _maphieu)
        {
            foreach (DataRow row in _PhieuCanData.LayPhieuCan(_maphieu).Rows)
            {
                _PhieuCanInfo.MaPhieu = row[0].ToString();
                _PhieuCanInfo.BSX = row[1].ToString();
                _PhieuCanInfo.KhachHang = row[2].ToString();
                _PhieuCanInfo.LoaiHang = row[3].ToString();
                _PhieuCanInfo.KLCanLan1 = decimal.Parse(row[4].ToString());
                //_PhieuCanInfo.KLCanLan2 = decimal.Parse(row[6].ToString());
                _PhieuCanInfo.LaiXe = row[12].ToString();
            }
            return _PhieuCanInfo;
        }


        public PhieuCanInfo LayCameraTheoPhieuCan(string _maphieu)
        {
            foreach (DataRow row in _PhieuCanData.LayPhieuCan3(_maphieu).Rows)
            {
                //load image cua 3 cam
                if (row["Cam1"] != System.DBNull.Value)
                    using (var ms = new MemoryStream((byte[])row["Cam1"]))
                    {
                        _PhieuCanInfo.Cam1 = Image.FromStream(ms);
                    }
                else
                    _PhieuCanInfo.Cam1 = null;

                if (row["Cam2"] != System.DBNull.Value)
                    using (var ms = new MemoryStream((byte[])row["Cam2"]))
                    {
                        _PhieuCanInfo.Cam2 = Image.FromStream(ms);
                    }
                else
                    _PhieuCanInfo.Cam2 = null;

                if (row["Cam3"] != System.DBNull.Value)
                    using (var ms = new MemoryStream((byte[])row["Cam3"]))
                    {
                        _PhieuCanInfo.Cam3 = Image.FromStream(ms);
                    }
                else
                    _PhieuCanInfo.Cam3 = null;
            }
            return _PhieuCanInfo;
        }

        public PhieuCanInfo LayPhieuCanTheoBSX(string bsx)
        {
            if ("Lấy biển số lỗi".Equals(bsx))  // neu loi bsx, tao phieu moi
                return null;

            PhieuCanInfo phieuCanInfo = null;
            foreach (DataRow row in _PhieuCanData.LayPhieuCanTheoBSX(bsx).Rows)
            {
                phieuCanInfo = new PhieuCanInfo();
                phieuCanInfo.MaPhieu = row["MaPhieu"].ToString();
                phieuCanInfo.BSX = row["BSX"].ToString();
                phieuCanInfo.KhachHang = row["KhachHang"].ToString();
                phieuCanInfo.LoaiHang = row["LoaiHang"].ToString();
                phieuCanInfo.KLCanLan1 = decimal.Parse(row["KLCanLan1"].ToString());
                if (!string.IsNullOrWhiteSpace(row["NgayCanLan1"].ToString()))
                    phieuCanInfo.NgayCanLan1 = DateTime.Parse(row["NgayCanLan1"].ToString());
                phieuCanInfo.DonGia = decimal.Parse(row["DonGia"].ToString());
                phieuCanInfo.LaiXe = row["LaiXe"].ToString();
            }
            return phieuCanInfo;
        }

        public PhieuCanInfo LayPhieuCan2(string _maphieu)
        {
            foreach (DataRow row in _PhieuCanData.LayPhieuCan2(_maphieu).Rows)
            {
                //_PhieuCanInfo.ID = row["ID"].ToString();
                _PhieuCanInfo.MaPhieu = row["MaPhieu"].ToString();
                _PhieuCanInfo.BSX = row["BSX"].ToString();
                _PhieuCanInfo.KhachHang = row["KhachHang"].ToString();
                _PhieuCanInfo.LoaiHang = row["LoaiHang"].ToString();
                if (row["KLCanLan1"].ToString() != "")
                {
                    _PhieuCanInfo.KLCanLan1 = decimal.Parse(row["KLCanLan1"].ToString());
                }
                if(row["KLCanLan2"].ToString() != "")
                {
                    _PhieuCanInfo.KLCanLan2 = decimal.Parse(row["KLCanLan2"].ToString());
                }
                if (row["KieuCanLan1"].ToString() != "")
                {
                    _PhieuCanInfo.KieuCanLan1 = row["KieuCanLan1"].ToString();
                }
                else
                {
                    _PhieuCanInfo.KieuCanLan1 = "";
                }
                if (row["KieuCanLan2"].ToString() != "")
                {
                    _PhieuCanInfo.KieuCanLan2 = row["KieuCanLan2"].ToString();
                }
                else
                {
                    _PhieuCanInfo.KieuCanLan2 = "";
                }
                if (row["NgayCanLan1"].ToString() != "")
                {
                    _PhieuCanInfo.NgayCanLan1 = DateTime.Parse(row["NgayCanLan1"].ToString());
                }
                if (row["NgayCanLan2"].ToString() != "")
                {
                    _PhieuCanInfo.NgayCanLan2 = DateTime.Parse(row["NgayCanLan2"].ToString());
                }
                if (row["TenNhanVienCanLan1"].ToString() != "")
                {
                    _PhieuCanInfo.TenNhanVienCanLan1 = row["TenNhanVienCanLan1"].ToString();
                }
                else
                {
                    _PhieuCanInfo.TenNhanVienCanLan1 = "";
                }
                if (row["TenNhanVienCanLan2"].ToString() != "")
                {
                    _PhieuCanInfo.TenNhanVienCanLan2 = row["TenNhanVienCanLan2"].ToString();
                }
                else
                {
                    _PhieuCanInfo.TenNhanVienCanLan2 = "";
                }
                /*
                if (row["MaNhanVienCanLan1"].ToString() != "")
                {
                    _PhieuCanInfo.MaNhanVienCanLan1 = row["MaNhanVienCanLan1"].ToString();
                }
                else
                {
                    _PhieuCanInfo.MaNhanVienCanLan1 = "";
                }
                if (row["MaNhanVienCanLan2"].ToString() != "")
                {
                    _PhieuCanInfo.MaNhanVienCanLan2 = row["MaNhanVienCanLan2"].ToString();
                }
                else
                {
                    _PhieuCanInfo.MaNhanVienCanLan2 = "";
                }
                */
                _PhieuCanInfo.LaiXe = row["LaiXe"].ToString();
                _PhieuCanInfo.DonGia = decimal.Parse(row["DonGia"].ToString());
                //_PhieuCanInfo.LanIn = decimal.Parse(row["LanIn"].ToString());
                _PhieuCanInfo.ChedoCan = row["CheDoCan"].ToString();
                if (row["BienSoXe"] != System.DBNull.Value)
                    using (var ms = new MemoryStream((byte[])row["BienSoXe"]))
                    {
                        _PhieuCanInfo.BienSoXe = Image.FromStream(ms);
                    }
                else
                    _PhieuCanInfo.BienSoXe = null;

                if (row["BienSoXeRa"] != System.DBNull.Value)
                    using (var ms = new MemoryStream((byte[])row["BienSoXeRa"]))
                    {
                        _PhieuCanInfo.BienSoXeRa = Image.FromStream(ms);
                    }
                else
                    _PhieuCanInfo.BienSoXeRa = null;
            }
            return _PhieuCanInfo;
        }

        public PhieuCanInfo LaySoLanIn(string _maphieu)
        {
            foreach (DataRow row in _PhieuCanData.LayPhieuCan(_maphieu).Rows)
            {
                _PhieuCanInfo.MaPhieu = row["MaPhieu"].ToString();
                _PhieuCanInfo.LanIn = decimal.Parse(row["LanIn"].ToString());
            }
            return _PhieuCanInfo;
        }
        #endregion

        #region Do du lieu vao DataGridView
        public void HienThi(DataGridViewX dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();
            
            bS.DataSource = _PhieuCanData.LayDsPhieuCan();
            bN.BindingSource = bS;
            dGV.DataSource = bS;
            dGV.Columns.Remove("ID");
            dGV.Columns.Remove("MaNhanVienCanLan1");
            dGV.Columns.Remove("MaNhanVienCanLan2");
            dGV.Columns.Remove("LanIn");
            dGV.Columns["DonGia"].DefaultCellStyle.Format = "#,###";
            dGV.Columns["KLCanLan1"].DefaultCellStyle.Format = "#,###";
            dGV.Columns["KLCanLan2"].DefaultCellStyle.Format = "#,###";
            dGV.Columns["NgayCanLan1"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
            dGV.Columns["NgayCanLan2"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
        }
        public void HienThi(DataGridViewX dGV, BindingNavigator bN, DateTime ngayCan, String lanCan, String bsx, String chedoCan)
        {            
            BindingSource bS = new BindingSource();
            switch (lanCan)
            {
                case "LAN1":
                    bS.DataSource = _PhieuCanData.LayDsPhieuChuaCanLan2(ngayCan, bsx, chedoCan);
                    break;
                case "LAN2":
                    bS.DataSource = _PhieuCanData.LayDsPhieuCanLan2(ngayCan, bsx, chedoCan);
                    break;
                default:
                    bS.DataSource = _PhieuCanData.LayDsPhieuCanTatCa(ngayCan, bsx, chedoCan);
                    break;
            }


            //bN.BindingSource = bS;
            //dGV.DataSource = bS;
            dGV.Invoke(new System.Action(() => dGV.DataSource = bS));

            if (bS.Count > 0)
            {                
                dGV.Columns["DonGia"].DefaultCellStyle.Format = "#,###";
                dGV.Columns["KLCanLan1"].DefaultCellStyle.Format = "#,###";
                dGV.Columns["KLCanLan2"].DefaultCellStyle.Format = "#,###";
                dGV.Columns["Khoiluong"].DefaultCellStyle.Format = "#,###";
                dGV.Columns["NgayCanLan1"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dGV.Columns["NgayCanLan2"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            /*
            else
            {
                //dGV.Columns["ID"].Visible = false;
                dGV.Columns["MaNhanVienCanLan1"].Visible = false;
                dGV.Columns["MaNhanVienCanLan2"].Visible = false;
                dGV.Columns["LanIn"].Visible = false;
            }
            */
        }
        #endregion

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return _PhieuCanData.ThemDongMoi();
        }

        public void ThemPhieuCan(DataRow m_Row)
        {
            _PhieuCanData.ThemPhieuCan(m_Row);
        }
        #endregion

        #region Luu du lieu
        public bool LuuPhieuCanLan1(PhieuCanInfo phieuCanInfo)
        {
            String toDayStr = DateTime.Now.ToString(quyDinh.yyyyMMdd);
            //String toDayHour = DateTime.Now.Hour.ToString();
            //String toDaySecond = DateTime.Now.Second.ToString();
            //String toDayMinute = DateTime.Now.Minute.ToString();
            String hhmmss = DateTime.Now.ToString("HHmmss");
            phieuCanInfo.ID = Guid.NewGuid().ToString();
            //phieuCanInfo.MaPhieu = toDayStr + toDayHour + toDayMinute + toDaySecond  /*quyDinh.LaySTT(_PhieuCanData.demSoPhieuTrongNgay(DateTime.Now))*/;
            phieuCanInfo.MaPhieu = toDayStr + hhmmss;
            phieuCanInfo.NgayCanLan1 = DateTime.Now;
            phieuCanInfo.TenNhanVienCanLan1 = Utilities.NguoiDung.TenND;
            phieuCanInfo.MaNhanVienCanLan1 = Utilities.NguoiDung.MaND;
            phieuCanInfo.LanIn = 1;
            phieuCanInfo.Cam1 = Utilities.Cam1;
            phieuCanInfo.Cam2 = Utilities.Cam2;
            phieuCanInfo.Cam3 = Utilities.Cam3;
            phieuCanInfo.BienSoXe = Utilities.BienSoXe;
            return _PhieuCanData.LuuCanlan1(phieuCanInfo);
        }

        public bool LuuPhieuCanTuDong(PhieuCanInfo phieuCanInfo)
        {
            // neu chua can lan nao, tao ma phieu moi
            if (string.IsNullOrEmpty(phieuCanInfo.MaPhieu))
            {
                String toDayStr = DateTime.Now.ToString(quyDinh.yyyyMMdd);
                String hhmmss = DateTime.Now.ToString("HHmmss");                
                phieuCanInfo.MaPhieu = toDayStr + hhmmss;

            }
            phieuCanInfo.ID = Guid.NewGuid().ToString();
            phieuCanInfo.TenNhanVienCanLan1 = Utilities.NguoiDung.TenND;
            phieuCanInfo.MaNhanVienCanLan1 = Utilities.NguoiDung.MaND;
            phieuCanInfo.LanIn = 1;
            phieuCanInfo.Cam1 = Utilities.Cam1; //cam truoc
            phieuCanInfo.Cam2 = Utilities.Cam3; //cam sau
            phieuCanInfo.Cam3 = Utilities.Cam4; //cam toan canh
            phieuCanInfo.BienSoXe = Utilities.BienSoXe;
            return _PhieuCanData.LuuPhieuCanTuDong(phieuCanInfo);
        }

        public bool LuuPhieuCanLan2(PhieuCanInfo phieuCanInfo)
        {
            phieuCanInfo.NgayCanLan2 = DateTime.Now;
            phieuCanInfo.TenNhanVienCanLan2 = Utilities.NguoiDung.TenND;
            phieuCanInfo.MaNhanVienCanLan2 = Utilities.NguoiDung.MaND;
            return _PhieuCanData.LuuCanlan2(phieuCanInfo);
        }

        public bool LuuPhieuCanBi(PhieuCanInfo phieuCanInfo)
        {
            phieuCanInfo.NgayCanLan1 = DateTime.Now;
            phieuCanInfo.TenNhanVienCanLan1 = Utilities.NguoiDung.TenND;
            phieuCanInfo.MaNhanVienCanLan1 = Utilities.NguoiDung.MaND;
            return _PhieuCanData.LuuCanBi(phieuCanInfo);
        }

        public bool LuuPhieuCanTong(PhieuCanInfo phieuCanInfo)
        {
            String toDayStr = DateTime.Now.ToString(quyDinh.yyyyMMdd);
            //String toDayHour = DateTime.Now.Hour.ToString();
            //String toDayMinute = DateTime.Now.Minute.ToString();
            //String toDaySecond = DateTime.Now.Second.ToString();
            String hhmmss = DateTime.Now.ToString("HHmmss");
            phieuCanInfo.ID = Guid.NewGuid().ToString();
            //phieuCanInfo.MaPhieu = toDayStr + toDayHour + toDayMinute + toDaySecond /*quyDinh.LaySTT(_PhieuCanData.demSoPhieuTrongNgay(DateTime.Now))*/;
            phieuCanInfo.MaPhieu = toDayStr + hhmmss;
            phieuCanInfo.NgayCanLan2 = DateTime.Now;
            phieuCanInfo.TenNhanVienCanLan2 = Utilities.NguoiDung.TenND;
            phieuCanInfo.MaNhanVienCanLan2 = Utilities.NguoiDung.MaND;
            phieuCanInfo.LanIn = 1;
            return _PhieuCanData.LuuCanTong(phieuCanInfo);
        }

        public bool SuaCanLan1(PhieuCanInfo phieuCanInfo)
        {
            return _PhieuCanData.SuaCanlan1(phieuCanInfo);
        }

        public bool SuaCanLan2(PhieuCanInfo phieuCanInfo)
        {
            return _PhieuCanData.SuaCanlan2(phieuCanInfo);
        }


        public bool XoaPhieuCan(PhieuCanInfo phieuCanInfo)
        {
            return _PhieuCanData.XoaPhieuCan(phieuCanInfo);
        }

        public bool XoaPhieuCan(string maphieu)
        {
            return _PhieuCanData.XoaPhieuCan(maphieu);
        }

        public bool LuuPhieuCan()
        {
            return _PhieuCanData.LuuPhieuCan();
        }

        public bool LuuLanIn(PhieuCanInfo phieuCanInfo)
        {
            return _PhieuCanData.LuuLanIn(phieuCanInfo);
        }
        #endregion

        #region Dem Phieu can
        public int DemPhieuCanLan1()
        {
            return _PhieuCanData.demSoPhieuTrongNgay(DateTime.Now);
        }

        public int DemPhieuCanLan2()
        {
            return _PhieuCanData.demSoPhieuLan2TrongNgay(DateTime.Now);
        }
        #endregion
        #region In phiếu cân
            public void InPhieuCan(string maphieu)
        {
             _PhieuCanData.InPhieuCan(maphieu);
        }
        #endregion

    }
}
