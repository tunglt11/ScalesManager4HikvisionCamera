using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class PhieuCanTDInfo
    {
        public PhieuCanTDInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private Decimal m_KLXe;
        public Decimal KLXe
        {
            get { return m_KLXe; }
            set { m_KLXe = value; }
        }
        private DateTime m_NgayGio;
        public DateTime NgayGio
        {
            get { return m_NgayGio; }
            set { m_NgayGio = value; }
        }
    }
}
