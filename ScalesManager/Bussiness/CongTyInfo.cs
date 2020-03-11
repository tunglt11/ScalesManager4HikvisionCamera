using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class CongTyInfo
    {
        public CongTyInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private String m_TenCT;
        public String TenCongTy
        {
            get { return m_TenCT; }
            set { m_TenCT = value; }
        }

        private String m_DiaChi;
        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }

        private String m_SDT;
        public String SDT
        {
            get { return m_SDT; }
            set { m_SDT = value; }
        }

        private String m_Fax;
        public String Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }        
    }
}
