using GalaSoft.MvvmLight;
using GamingDnV.Enums;
using GamingDnV.Models;
using GamingDnV.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Services
{
    public class UpdataBD : ViewModelBase
    {
        
        public static string constr = "provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
        //public static string constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        //public static string constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";
        //public static void ConnectBD()
        //{
        //    if (SelectBD is null)
        //    {
        //        constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        //    }
        //    else
        //    {
        //        if (SelectBD.BD == "Бой")
        //        {
        //            constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";
        //        }
        //        else
        //        {
        //            constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        //        }
        //    }
        //}

        public static TypeResult TestConnect(string conn)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(conn);
                mycon.Open();
                mycon.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static TypeResult Update(string sql, string conn)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(conn);
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
        public static void UpdataInDb(string sql, string conn)
        {
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            myCommand.ExecuteReader();
            myCommand.Clone();
        }

        public static async Task<TypeResult> UpdateHero(PersonModel Hero, string conn)
        {
            try
            {
                //Обновление добавление героя
                string sql = "";
                int Id = await GetIdAsunc(Hero.Id, "wp_heros", conn);
                if (Id == 0)
                {
                    sql = "INSERT INTO `wp_heros`(`id`, `Name`, `Notee`, `Defence`, `Health`, `Power`, `P`, `Dexterity`, `D`, `Endurance`, `E`, `Wisdom`, `W`, `Intelligence`, `I`, `Charisma`, `C`, `Passiv`, `Species`, `Class`, `History`, `Imag`, `Gold`, `Ervaring`) VALUES (" + Hero.Id + ",'" + Hero.Name + "','" + Hero.Notee + "'," + Hero.Defence + "," + Hero.Health + "," + Hero.Power + "," + Hero.P + "," + Hero.Dexterity + "," + Hero.D + "," + Hero.Endurance + "," + Hero.E + "," + Hero.Wisdom + "," + Hero.W + "," + Hero.Intelligence + "," + Hero.I + "," + Hero.Charisma + "," + Hero.C + "," + Hero.Passiv + ",'" + Hero.Species + "','" + Hero.Class + "','" + Hero.History + "','" + Hero.Imag + "'," + Hero.Gold + "," + Hero.Ervaring + ")";
                }
                else
                {
                    sql = "UPDATE `wp_heros` SET `Name`='" + Hero.Name + "', `Notee`='" + Hero.Notee + "', `Defence`=" + Hero.Defence + ", `Health`=" + Hero.Health + ", `Power`=" + Hero.Power + ", `P`=" + Hero.P + ", `Dexterity`=" + Hero.Dexterity + ", `D`=" + Hero.D + ", `Endurance`= " + Hero.Endurance + ", `E`=" + Hero.E + ", `Wisdom`= " + Hero.Wisdom + ", `W`=" + Hero.W + ", `Intelligence`= " + Hero.Intelligence + ", `I`=" + Hero.I + ", `Charisma`= " + Hero.Charisma + ", `C`=" + Hero.C + ", `Passiv`=" + Hero.Passiv + ", `Species`='" + Hero.Species + "', `Class`='" + Hero.Class + "', `History`='" + Hero.History + "', `Imag`='" + Hero.Imag + "', `Gold`= " + Hero.Gold + ", `Ervaring`= " + Hero.Ervaring + " WHERE `id`= " + Id;
                }
                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<TypeResult> UpdateAbil(AbilitiesModel a, string table, int IdHero, string conn)
        {
            try
            {
                //Обновление добавление способностей
                string sql = "";
                int Id = await GetIdAsunc(a.Id, table, conn);
                if (Id == 0)
                {
                    sql = "INSERT INTO `"+ table + "`(`id`, `Name`, `Notee`, `IdPerson`, `Enabled`, `Order`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.IdPerson + "," + a.Enabled + "," + a.Order + ")";
                }
                else
                {
                    sql = "UPDATE `"+ table + "` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `IdPerson`=" + IdHero + ", `Enabled`=" + a.Enabled + ", `Order`=" + a.Order +" WHERE `id`= " + Id;
                }
                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<TypeResult> UpdateItem_0(string table, int IdHero, string conn)
        {
            try
            {
                //Обновление добавление Нуливый предметов
                string sql = "";
                string sql_0 = "UPDATE `" + table + "` SET `IdPerson`=0 WHERE `IdPerson`= " + IdHero;
                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql_0, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                myConnect.Open();
                myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<TypeResult> UpdateItem(ItemsModel a, string table, int IdHero, string conn)
        {
            try
            {
                //Обновление добавление предметов
                string sql = "";
                int Id = await GetIdAsunc(a.Id, table, conn);
                if (Id == 0)
                {
                    sql = "INSERT INTO `"+ table + "`(`id`, `IdItemShop`, `IdPerson`, `Count`) VALUES (" + a.Id + ", " + a.IdItemShop + "," + a.IdPerson + "," + a.Count + ")";
                }
                else
                {
                    sql = "UPDATE `"+ table + "` SET `IdItemShop`=" + a.IdItemShop + ", `IdPerson`=" + IdHero + ", `Count`=" + a.Count + " WHERE `id`= " + Id;
                }
                string sql_0 = "UPDATE `" + table + "` SET `IdPerson`= 0 WHERE `id`= " + Id;
                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql_0, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                myConnect.Open();
                myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<int> GetIdAsunc(int id, string table, string conn)
        {
            int Id = 0;
            await Task.Run(() =>
            {
                string sql_id_search = "SELECT `id` FROM `"+ table + "` WHERE `id` = " + id;

                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql_id_search, myConnect);
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader[0].ToString());
                }
                myConnect.Close();
            
            });
            return Id;
        }

        public static async Task<TypeResult> UpdateShop(ItemsModel a, string table, string conn)
        {
            try
            {
                //Обновление добавление пердметов магазина
                string sql = "";
                int Id = await GetIdAsunc(a.Id, table, conn);
                if (Id == 0)
                {
                    sql = "INSERT INTO `wp_shop`(`id`, `Name`, `Notee`, `Count`, `Type`, `Price`, `Imag`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.Count + "," + a.Type + "," + a.Price + ",'" + a.Imag + "')";
                }
                else
                {
                    sql = "UPDATE `wp_shop` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `Count`=" + a.Count + ", `Type`=" + a.Type + ", `Price`=" + a.Price + ", `Imag`='" + a.Imag + "' WHERE `id`= " + Id;
                }

                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<TypeResult> UpdateItem(ItemsModel a, string table, string conn)
        {
            try
            {
                //Обновление добавление предметов
                string sql = "";
                int Id = await GetIdAsunc(a.Id, table, conn);
                if (Id == 0)
                {
                    sql = "INSERT INTO `wp_items`(`id`, `Name`, `Notee`, `IdPerson`, `Count`, `Imag`, `Type`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.IdPerson + "," + a.Count + ",'" + a.Imag + "', " + a.Type + ")";
                }
                else
                {
                    sql = "UPDATE `wp_items` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `IdPerson`=0, `Count`=" + a.Count + ", `Imag`='" + a.Imag + "' WHERE `id`= " + Id;
                }
                string sql_0 = "UPDATE `" + table + "` SET `IdPerson`=0 WHERE `id`= " + Id;
                MySqlConnection myConnect = new MySqlConnection(conn);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql_0, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                myConnect.Open();
                myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }

        public static async Task<TypeResult> UpdateHero(PersonModel d, string table, string conn)
        {
            try
            {
                //Обновление добавление пердметов магазина
                string sql = "";

                sql = "UPDATE `wp_heros` SET `Defence`=" + d.Defence + ",`Health`=" + d.Health + ",`Power`=" + d.Power + ",`Dexterity`=" + d.Dexterity + ",`Endurance`=" + d.Endurance + ",`Wisdom`=" + d.Wisdom + ",`Intelligence`=" + d.Intelligence + ",`Charisma`=" + d.Charisma + ", `Gold`=" + d.Gold + ", `Ervaring`=" + d.Ervaring + " WHERE `Id`=" + d.Id;
                
                await Task.Run(() =>
                {
                    MySqlConnection myConnect = new MySqlConnection(conn);
                    myConnect.Open();
                    MySqlCommand myCommand = new MySqlCommand(sql, myConnect);
                    myCommand.ExecuteReader();
                    myConnect.Close();
                });
                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }
    }
}
