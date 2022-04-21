using GamingDnV.Enums;
using MySql.Data.MySqlClient;
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
        //public static string constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        public static string constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";

        public static TypeResult TestConnect()
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(constrInt);
                mycon.Open();
                mycon.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static TypeResult Update(string sql)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(constrInt);
                mycon.Open();
                MySqlCommand mycom = new MySqlCommand(sql, mycon);
                mycom.ExecuteReader();
                mycon.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }
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
