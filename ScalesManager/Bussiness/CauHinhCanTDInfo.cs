using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScalesManager.Bussiness
{
    class CauHinhCanTDInfo
    {
        public CauHinhCanTDInfo()
        {

        }

        private String m_ID;
        public String ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private int m_TimeSleep;
        public int TimeSleep
        {
            get { return m_TimeSleep; }
            set { m_TimeSleep = value; }
        }
        private decimal m_KhoiLuong;
        public decimal KhoiLuong
        {
            get { return m_KhoiLuong; }
            set { m_KhoiLuong = value; }
        }
    }
}
