using GamingDnV.Enums;
using GamingDnV.Models;
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
    public class UpdataBD
    {
        public static string constr = "provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";
        public static string constrInt = "Server=localhost;Uid=user_root;pwd=1111;Database=vh258049_su;charset=utf8;";
        //public static string constrInt = "Server=83.69.230.5;Uid=vh258049_suvenir;pwd=Tii6e2vI;Database=vh258049_su;charset=utf8;";

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

        public static TypeResult UpdateHero(PersonModel Hero, List<AbilitiesModel> Abil, List<AbilitiesModel> Ulta, List<ItemsModel> Item)
        {
            try
            {
                //Обновление добавление героя
                string sql_hero_search = "SELECT `id` FROM `wp_heros` WHERE `id` = " + Hero.Id;
                string sql = "";
                int Id = 0;
                MySqlConnection myConnect = new MySqlConnection(constrInt);
                myConnect.Open();
                MySqlCommand myCommand = new MySqlCommand(sql_hero_search, myConnect);
                MySqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    Id = Convert.ToInt32(reader[0].ToString());
                }
                myConnect.Close();

                if (Id == 0)
                {
                    sql = "INSERT INTO `wp_heros`(`id`, `Name`, `Notee`, `Defence`, `Health`, `Power`, `P`, `Dexterity`, `D`, `Endurance`, `E`, `Wisdom`, `W`, `Intelligence`, `I`, `Charisma`, `C`, `Passiv`, `Species`, `Class`, `History`, `Imag`, `Arms`, `Equip`, `Gold`, `Ervaring`) VALUES (" + Hero.Id + ",'" + Hero.Name + "','" + Hero.Notee + "'," + Hero.Defence + "," + Hero.Health + "," + Hero.Power + "," + Hero.P + "," + Hero.Dexterity + "," + Hero.D + "," + Hero.Endurance + "," + Hero.E + "," + Hero.Wisdom + "," + Hero.W + "," + Hero.Intelligence + "," + Hero.I + "," + Hero.Charisma + "," + Hero.C + "," + Hero.Passiv + ",'" + Hero.Species + "','" + Hero.Class + "','" + Hero.History + "','" + Hero.Imag + "','" + Hero.Arms + "','" + Hero.Equip + "'," + Hero.Gold + "," + Hero.Ervaring + ")";
                }
                else
                {
                    sql = "UPDATE `wp_heros` SET `Name`='"+Hero.Name+"', `Notee`='"+Hero.Notee+"', `Defence`="+Hero.Defence+", `Health`="+Hero.Health+", `Power`="+Hero.Power+", `P`="+Hero.P+", `Dexterity`="+Hero.Dexterity+", `D`="+Hero.D+", `Endurance`= " + Hero.Endurance + ", `E`=" + Hero.E + ", `Wisdom`= " + Hero.Wisdom + ", `W`=" + Hero.W + ", `Intelligence`= " + Hero.Intelligence + ", `I`=" + Hero.I + ", `Charisma`= " + Hero.Charisma + ", `C`=" + Hero.C + ", `Passiv`="+Hero.Passiv+ ", `Species`='" + Hero.Species+"', `Class`='"+Hero.Class+"', `History`='"+Hero.History+"', `Imag`='"+Hero.Imag+"', `Arms`='"+Hero.Arms+"', `Equip`='"+Hero.Equip+"', `Gold`= " + Hero.Gold + ", `Ervaring`= " + Hero.Ervaring + " WHERE `id`= " + Id;
                }

                myConnect.Open();
                myCommand = new MySqlCommand(sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();

                //Обновление добавление Способностей
                foreach (var a in Abil)
                {
                    string sql_Abil = "SELECT `id` FROM `wp_abilities` WHERE `id` = " + a.Id;
                    Id = 0;
                    myConnect = new MySqlConnection(constrInt);
                    myConnect.Open();
                    myCommand = new MySqlCommand(sql_Abil, myConnect);
                    reader = myCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = Convert.ToInt32(reader[0].ToString());
                    }
                    myConnect.Close();
                    if (Id == 0)
                    {
                        sql = "INSERT INTO `wp_abilities`(`id`, `Name`, `Notee`, `IdPerson`, `Enabled`, `Order`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.IdPerson + "," + a.Enabled + "," + a.Order + ")";
                    }
                    else
                    {
                        sql = "UPDATE `wp_abilities` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `IdPerson`=" + Hero.Id + ", `Enabled`=" + a.Enabled + ", `Order`=" + a.Order +" WHERE `id`= " + Id;
                    }

                    myConnect.Open();
                    myCommand = new MySqlCommand(sql, myConnect);
                    myCommand.ExecuteReader();
                    myConnect.Close();
                }

                //Обновление добавление Заклинаний
                foreach (var a in Ulta)
                {
                    string sql_Ulta = "SELECT `id` FROM `wp_ulta` WHERE `id` = " + a.Id;
                    Id = 0;
                    myConnect = new MySqlConnection(constrInt);
                    myConnect.Open();
                    myCommand = new MySqlCommand(sql_Ulta, myConnect);
                    reader = myCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = Convert.ToInt32(reader[0].ToString());
                    }
                    myConnect.Close();
                    if (Id == 0)
                    {
                        sql = "INSERT INTO `wp_ulta`(`id`, `Name`, `Notee`, `IdPerson`, `Enabled`, `Order`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.IdPerson + "," + a.Enabled + "," + a.Order + ")";
                    }
                    else
                    {
                        sql = "UPDATE `wp_ulta` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `IdPerson`=" + Hero.Id + ", `Enabled`=" + a.Enabled + ", `Order`=" + a.Order + " WHERE `id`= " + Id;
                    }

                    myConnect.Open();
                    myCommand = new MySqlCommand(sql, myConnect);
                    myCommand.ExecuteReader();
                    myConnect.Close();
                }

                //Обновление добавление Вещей
                foreach (var a in Item)
                {
                    string sql_Item = "SELECT `id` FROM `wp_items` WHERE `id` = " + a.Id;
                    Id = 0;
                    myConnect = new MySqlConnection(constrInt);
                    myConnect.Open();
                    myCommand = new MySqlCommand(sql_Item, myConnect);
                    reader = myCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Id = Convert.ToInt32(reader[0].ToString());
                    }
                    myConnect.Close();
                    if (Id == 0)
                    {
                        sql = "INSERT INTO `wp_items`(`id`, `Name`, `Notee`, `IdPerson`, `Count`, `Imag`) VALUES (" + a.Id + ",'" + a.Name + "','" + a.Notee + "'," + a.IdPerson + "," + a.Count + ",'" + a.Imag + "')";
                    }
                    else
                    {
                        sql = "UPDATE `wp_items` SET `Name`='" + a.Name + "', `Notee`='" + a.Notee + "', `IdPerson`=" + Hero.Id + ", `Count`=" + a.Count + ", `Imag`='" + a.Imag + "' WHERE `id`= " + Id;
                    }

                    myConnect.Open();
                    myCommand = new MySqlCommand(sql, myConnect);
                    myCommand.ExecuteReader();
                    myConnect.Close();
                }

                return TypeResult.Ok;
            }
            catch
            {
                return TypeResult.Error;
            }
        }
    }
}
