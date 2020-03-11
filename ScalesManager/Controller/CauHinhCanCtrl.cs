using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;

namespace ScalesManager.Controller
{
    class CauHinhCanCtrl
    {
        CauHinhCanData m_CauHinhCanData = new CauHinhCanData();
        CauHinhCanInfo m_CauHinhCanInfo = new CauHinhCanInfo();

        string id;

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_CauHinhCanData.ThemDongMoi();
        }

        public void ThemCauHinh(DataRow m_Row)
        {
            m_CauHinhCanData.ThemCauHinhCan(m_Row);
        }
        #endregion

        #region Luu du lieu

        public bool LuuCauHinh_Lan1(CauHinhCanInfo cauHinhCanInfo)
        {
            return m_CauHinhCanData.LuuCauHinhCanLan1(cauHinhCanInfo);
        }

        public bool LuuCauHinh_LanN(CauHinhCanInfo cauHinhCanInfo)
        {
            return m_CauHinhCanData.LuuCauHinhCanLanN(cauHinhCanInfo);
        }

        #endregion

        #region dem so cau hinh can ghien co tron data
        public int DemCauHinhCan()
        {
            return m_CauHinhCanData.LayIDCauHinhCan().Rows.Count;
        }

        public string LayIDCauHinh()
        {
            foreach (DataRow row in m_CauHinhCanData.LayIDCauHinhCan().Rows)
            {
                id = row[0].ToString();
            }
            return id;
        }
        #endregion
        #region
        public CauHinhCanInfo LayCauHinhCan()
        {
            foreach(DataRow row in m_CauHinhCanData.LayCauHinhCan().Rows)
            {
                m_CauHinhCanInfo.ID = row[0].ToString();
                m_CauHinhCanInfo.COM = row[1].ToString();
                m_CauHinhCanInfo.RAUDRATE = row[2].ToString();
                m_CauHinhCanInfo.DATABITS = row[3].ToString();
                m_CauHinhCanInfo.PARITY = row[4].ToString();
                m_CauHinhCanInfo.STOPBIT = row[5].ToString();
                m_CauHinhCanInfo.DATALENGHT = row[6].ToString();
                m_CauHinhCanInfo.SFROM = row[7].ToString();
                m_CauHinhCanInfo.STO = row[8].ToString();
                m_CauHinhCanInfo.KiTuNgat = row[9].ToString();
            }
            return m_CauHinhCanInfo;
        }
        #endregion
    }
}
