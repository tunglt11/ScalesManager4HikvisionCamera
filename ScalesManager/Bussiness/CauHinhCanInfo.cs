using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class CauHinhCanInfo
    {
        public CauHinhCanInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private String m_COM;
        public String COM
        {
            get { return m_COM; }
            set { m_COM = value; }
        }

        private String m_RAUDRATE;
        public String RAUDRATE
        {
            get { return m_RAUDRATE; }
            set { m_RAUDRATE = value; }
        }

        private String m_DATABITS;
        public String DATABITS
        {
            get { return m_DATABITS; }
            set { m_DATABITS = value; }
        }

        private String m_PARITY;
        public String PARITY
        {
            get { return m_PARITY; }
            set { m_PARITY = value; }
        }

        private String m_STOPBIT;
        public String STOPBIT
        {
            get { return m_STOPBIT; }
            set { m_STOPBIT = value; }
        }

        private String m_DATALENGHT;
        public String DATALENGHT
        {
            get { return m_DATALENGHT; }
            set { m_DATALENGHT = value; }
        }

        private String m_FROM;
        public String SFROM
        {
            get { return m_FROM; }
            set { m_FROM = value; }
        }

        private String m_TO;
        public String STO
        {
            get { return m_TO; }
            set { m_TO = value; }
        }

        private String m_KiTuNgat;
        public String KiTuNgat
        {
            get { return m_KiTuNgat; }
            set { m_KiTuNgat = value; }
        }
    }
}
