using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Services
{
    public class UpdataBD
    {
        public static string constr = "provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";

        public static void UpdataInDb(string sql)
        {
            //string sql = "DELETE FROM `Orders` WHERE Id=" + Id + "";
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            myCommand.ExecuteReader();
            myCommand.Clone();
        }
    }
}
