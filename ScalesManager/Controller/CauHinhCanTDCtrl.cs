using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;

namespace ScalesManager.Controller
{
    class CauHinhCanTDCtrl
    {
        CauHinhCanTDData m_CauHinhCanTDData = new CauHinhCanTDData();
        CauHinhCanTDInfo m_CauHinhCanTDInfo = new CauHinhCanTDInfo();

        string id;

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_CauHinhCanTDData.ThemDongMoi();
        }

        public void ThemCauHinh(DataRow m_Row)
        {
            m_CauHinhCanTDData.ThemCauHinhCan(m_Row);
        }
        #endregion

        #region Luu du lieu

        public bool LuuCauHinh_Lan1(CauHinhCanTDInfo cauHinhCanTDInfo)
        {
            return m_CauHinhCanTDData.LuuCauHinhCanLan1(cauHinhCanTDInfo);
        }

        public bool LuuCauHinh_LanN(CauHinhCanTDInfo cauHinhCanTDInfo)
        {
            return m_CauHinhCanTDData.LuuCauHinhCanLanN(cauHinhCanTDInfo);
        }

        #endregion

        #region dem so cau hinh can ghien co tron data
        public int DemCauHinhCan()
        {
            return m_CauHinhCanTDData.LayIDCauHinhCan().Rows.Count;
        }

        public string LayIDCauHinh()
        {
            foreach (DataRow row in m_CauHinhCanTDData.LayIDCauHinhCan().Rows)
            {
                id = row[0].ToString();
            }
            return id;
        }
        #endregion
        #region
        public CauHinhCanTDInfo LayCauHinhCan()
        {
            foreach (DataRow row in m_CauHinhCanTDData.LayCauHinhCan().Rows)
            {
                m_CauHinhCanTDInfo.ID = row[0].ToString();
                m_CauHinhCanTDInfo.TimeSleep = int.Parse(row[1].ToString());
                m_CauHinhCanTDInfo.KhoiLuong = decimal.Parse(row[2].ToString());
            }
            return m_CauHinhCanTDInfo;
        }
        #endregion
    }
}
