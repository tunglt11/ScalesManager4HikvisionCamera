using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ScalesManager.Bussiness;

namespace ScalesManager.DataLayer
{
    class KeysData
    {
        DataService m_KeysData = new DataService();

        public DataTable LayKey()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Keys");
            m_KeysData.Load(cmd);
            return m_KeysData;
        }

        public bool LuuKeys(KeysInfo keysInfo)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Keys " +
                "SET DateStart = @DataStart " +
                " where ID = @ID");
            cmd.Parameters.Add("ID", SqlDbType.VarChar).Value = keysInfo.ID;
            cmd.Parameters.Add("DataStart", SqlDbType.Date).Value = keysInfo.StartDate;

            return m_KeysData.ExecuteNoneQuery(cmd) > 0;
        }
    }
}
