using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class KhachHangInfo
    {
        public KhachHangInfo()
        {

        }

        private String m_MaKH;
        public String MaKH
        {
            get { return m_MaKH; }
            set { m_MaKH = value; }
        }

        private String m_TenKH;
        public String TenKH
        {
            get { return m_TenKH; }
            set { m_TenKH = value; }
        }

        private String m_SDT;
        public String SDT
        {
            get { return m_SDT; }
            set { m_SDT = value; }
        }

        private String m_DiaChi;
        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
    }
}
