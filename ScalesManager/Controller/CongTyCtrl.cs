using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;

namespace ScalesManager.Controller
{
    class CongTyCtrl
    {
        CongTyData m_congTyData = new CongTyData();
        CongTyInfo m_congTyInfo = new CongTyInfo();

        string id;

        #region Them moi
        public DataRow ThemDongMoi()
        {
            return m_congTyData.ThemDongMoi();
        }

        public void ThemThongTinCT(DataRow m_Row)
        {
            m_congTyData.ThemThongTinCT(m_Row);
        }
        #endregion

        #region Luu du lieu

        public bool LuuThongTinCT_Lan1(CongTyInfo congTyInfo)
        {
            return m_congTyData.LuuThongTinCTLan1(congTyInfo);
        }

        public bool LuuThongTinCT_LanN(CongTyInfo congTyInfo)
        {
            return m_congTyData.LuuThongTinCTLanN(congTyInfo);
        }
        #endregion

        #region dem so dong thong tin co trong data
        public int DemThongTinCT()
        {
            return m_congTyData.LayIDCongTy().Rows.Count;
        }

        public string LayIDThongTinCT()
        {
            foreach (DataRow row in m_congTyData.LayIDCongTy().Rows)
            {
                id = row[0].ToString();
            }
            return id;
        }
        #endregion
        #region
        public CongTyInfo LayThongTinCT()
        {
            foreach (DataRow row in m_congTyData.LayThongTinCT().Rows)
            {
                m_congTyInfo.ID = row[0].ToString();
                m_congTyInfo.TenCongTy = row[1].ToString();
                m_congTyInfo.DiaChi = row[2].ToString();
                m_congTyInfo.SDT = row[3].ToString();
                m_congTyInfo.Fax = row[4].ToString();
            }
            return m_congTyInfo;
        }
        #endregion
    }
}
