using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class XeInfo
    {
        public XeInfo()
        {

        }

        private string _BSX;
        private int _TrongLuong;
        private string _Khachhang;
        private string _TaiXe;
        private string _LoaiXe;

        public string BSX { get => _BSX; set => _BSX = value; }
        public int TrongLuong { get => _TrongLuong; set => _TrongLuong = value; }
        public string Khachhang { get => _Khachhang; set => _Khachhang = value; }
        public string TaiXe { get => _TaiXe; set => _TaiXe = value; }
        public string LoaiXe { get => _LoaiXe; set => _LoaiXe = value; }
    }
}
