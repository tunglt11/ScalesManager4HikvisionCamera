using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class CauHinhMayInInfo
    {
        public CauHinhMayInInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private String m_Ten;
        public String TenMayIn
        {
            get { return m_Ten; }
            set { m_Ten = value; }
        }

        private String m_SoPhieu;
        public String SoPhieu
        {
            get { return m_SoPhieu; }
            set { m_SoPhieu = value; }
        }
    }
}
