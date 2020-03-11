using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScalesManager.Bussiness;
using ScalesManager.DataLayer;
using System.Data;


namespace ScalesManager.Controller
{
    class KeysCtrl
    {
        KeysData m_KeysData = new KeysData();
        KeysInfo m_KeysInfo = new KeysInfo();

        #region
        public KeysInfo LayKey()
        {
            foreach (DataRow row in m_KeysData.LayKey().Rows)
            {
                m_KeysInfo.ID = row[0].ToString();
                m_KeysInfo.Keys = row[1].ToString();
                m_KeysInfo.StartDate = (DateTime)row[2];
                m_KeysInfo.EndDate = (DateTime)row[3];
            }
            return m_KeysInfo;
        }
        #endregion

        public bool LuuKeys(KeysInfo keysInfo)
        {
            return m_KeysData.LuuKeys(keysInfo);
        }
    }
}
