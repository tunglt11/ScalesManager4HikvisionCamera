using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class KeysInfo
    {
        public KeysInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private String m_Keys;
        public String Keys
        {
            get { return m_Keys; }
            set { m_Keys = value; }
        }

        private DateTime m_StartDate;
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        private DateTime m_EndDate;
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }
    }
}
