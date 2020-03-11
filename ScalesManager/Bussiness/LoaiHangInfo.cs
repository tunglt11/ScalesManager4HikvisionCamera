using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class LoaiHangInfo
    {
        public LoaiHangInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private String m_LoaiHang;
        public String LoaiHang
        {
            get { return m_LoaiHang; }
            set { m_LoaiHang = value; }
        }

        private Decimal m_DonGia;
        public Decimal DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }

       
    }
}
