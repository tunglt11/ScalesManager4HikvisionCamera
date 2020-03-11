using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
   public class PhieuCanInfo
    {
        private String _ID;
        private String _MaPhieu;
        private String _BSX;
        private String _KhachHang;
        private String _LoaiHang;
        private Decimal _KLCanLan1;
        private Decimal _KLCanLan2;
        private String _KieuCanLan1;
        private String _KieuCanLan2;
        private DateTime _NgayCanLan1;
        private DateTime _NgayCanLan2;
        private String _TenNhanVienCanLan1;
        private String _TenNhanVienCanLan2;
        private String _MaNhanVienCanLan1;
        private String _MaNhanVienCanLan2;
        private String _LaiXe;
        private Decimal _DonGia;
        private Decimal _LanIn;
        private String _ChedoCan;
        private Image _Cam1;
        private Image _Cam2;
        private Image _Cam3;
        private Image _BienSoXe;
        private Image _BienSoXeRa;

        public PhieuCanInfo()
        {
        }

        public string ID { get => _ID; set => _ID = value; }
        public string MaPhieu { get => _MaPhieu; set => _MaPhieu = value; }
        public string BSX { get => _BSX; set => _BSX = value; }
        public string KhachHang { get => _KhachHang; set => _KhachHang = value; }
        public string LoaiHang { get => _LoaiHang; set => _LoaiHang = value; }
        public Decimal KLCanLan1 { get => _KLCanLan1; set => _KLCanLan1 = value; }
        public Decimal KLCanLan2 { get => _KLCanLan2; set => _KLCanLan2 = value; }
        public string KieuCanLan1 { get => _KieuCanLan1; set => _KieuCanLan1 = value; }
        public string KieuCanLan2 { get => _KieuCanLan2; set => _KieuCanLan2 = value; }
        public DateTime NgayCanLan1 { get => _NgayCanLan1; set => _NgayCanLan1 = value; }
        public DateTime NgayCanLan2 { get => _NgayCanLan2; set => _NgayCanLan2 = value; }
        public string TenNhanVienCanLan1 { get => _TenNhanVienCanLan1; set => _TenNhanVienCanLan1 = value; }
        public string TenNhanVienCanLan2 { get => _TenNhanVienCanLan2; set => _TenNhanVienCanLan2 = value; }
        public string MaNhanVienCanLan1 { get => _MaNhanVienCanLan1; set => _MaNhanVienCanLan1 = value; }
        public string MaNhanVienCanLan2 { get => _MaNhanVienCanLan2; set => _MaNhanVienCanLan2 = value; }
        public string LaiXe { get => _LaiXe; set => _LaiXe = value; }
        public Decimal DonGia { get => _DonGia; set => _DonGia = value; }
        public Decimal LanIn { get => _LanIn; set => _LanIn = value; }
        public string ChedoCan { get => _ChedoCan; set => _ChedoCan = value; }
        public Image Cam1 { get => _Cam1; set => _Cam1 = value; }
        public Image Cam2 { get => _Cam2; set => _Cam2 = value; }
        public Image Cam3 { get => _Cam3; set => _Cam3 = value; }
        public Image BienSoXe { get => _BienSoXe; set => _BienSoXe = value; }
        public Image BienSoXeRa { get => _BienSoXeRa; set => _BienSoXeRa = value; }
    }
}
