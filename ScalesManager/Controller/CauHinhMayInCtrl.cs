using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;

namespace ScalesManager.Controller
{
    class CauHinhMayInCtrl
    {
        CauHinhMayInData m_cauHinhMayInData = new CauHinhMayInData();
        CauHinhMayInInfo m_cauHinhMayInInfo = new CauHinhMayInInfo();

        string id;

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_cauHinhMayInData.ThemDongMoi();
        }

        public void ThemMayIn(DataRow m_Row)
        {
            m_cauHinhMayInData.ThemCauHinhMayIn(m_Row);
        }
        #endregion

        #region Luu du lieu

        public bool LuuCauHinhMayIn_Lan1(CauHinhMayInInfo cauHinhMayInInfo)
        {
            return m_cauHinhMayInData.LuuCauHinhMayInLan1(cauHinhMayInInfo);
        }

        public bool LuuCauHinhMayIn_LanN(CauHinhMayInInfo cauHinhMayInInfo)
        {
            return m_cauHinhMayInData.LuuCauHinhMayInLanN(cauHinhMayInInfo);
        }

        #endregion

        #region dem so cau hinh can ghien co tron data
        public int DemCauHinhMayIn()
        {
            return m_cauHinhMayInData.LayIDCauHinhMayIn().Rows.Count;
        }

        public string LayIDCauHinhMayIn()
        {
            foreach (DataRow row in m_cauHinhMayInData.LayIDCauHinhMayIn().Rows)
            {
                id = row[0].ToString();
            }
            return id;
        }
        #endregion
        #region
        public CauHinhMayInInfo LayCauHinhCanMayIn()
        {
            foreach (DataRow row in m_cauHinhMayInData.LayCauHinhMayIn().Rows)
            {
                m_cauHinhMayInInfo.ID = row[0].ToString();
                m_cauHinhMayInInfo.TenMayIn = row[1].ToString();
                m_cauHinhMayInInfo.SoPhieu = row[2].ToString();
            }
            return m_cauHinhMayInInfo;
        }
        #endregion
    }
}
