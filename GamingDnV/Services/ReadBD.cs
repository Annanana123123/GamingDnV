using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingDnV.Models;

namespace GamingDnV.Services
{
    public class ReadBD
    {
        public static string constr = "provider=Microsoft.Jet.OLEDB.4.0;data source=database.mdb";

        public static ObservableCollection<EventsModel> ReadEventInDb(string sql)
        {
            //Id, Name, TextEvent, Images, Sounds, Order
            ObservableCollection<EventsModel> Events = new ObservableCollection<EventsModel>();
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Events.Add(new EventsModel()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    Name = Convert.ToString(reader[1].ToString()),
                    TextEvent = Convert.ToString(reader[2].ToString()),
                    Images = Convert.ToString(reader[3].ToString()),
                    Sounds = Convert.ToString(reader[4].ToString()),
                    Order = Convert.ToInt32(reader[5].ToString()),
                    RoomId = Convert.ToInt32(reader[6].ToString())
                });
            }
            myConnect.Close();
            return Events;
        }

        public static ObservableCollection<RoomsModel> ReadRoomsInDb(string sql)
        {
            ObservableCollection<RoomsModel> Rooms = new ObservableCollection<RoomsModel>();
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Rooms.Add(new RoomsModel()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    Name = Convert.ToString(reader[1].ToString()),
                    TextRoom = Convert.ToString(reader[2].ToString()),
                    Images = Convert.ToString(reader[3].ToString()),
                    Sounds = Convert.ToString(reader[4].ToString())
                });
            }
            myConnect.Close();
            return Rooms;
        }

        public static List<ComboBoxModel> ReadHistory(string sql)
        {
            List<ComboBoxModel> Users = new List<ComboBoxModel>();
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Users.Add(new ComboBoxModel()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    History = Convert.ToString(reader[1].ToString())
                });
            }
            myConnect.Close();
            return Users;
        }

        public static ObservableCollection<UsersModel> ReadUsersInDb(string sql)
        {
            ObservableCollection<UsersModel> Users = new ObservableCollection<UsersModel>();
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                Users.Add(new UsersModel()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    HeroName = Convert.ToString(reader[1].ToString()),
                    Notee = Convert.ToString(reader[2].ToString()),
                    Defence = Convert.ToInt32(reader[3].ToString()),
                    Health = Convert.ToInt32(reader[4].ToString()),
                    Power = Convert.ToInt32(reader[5].ToString()),
                    Dexterity = Convert.ToInt32(reader[6].ToString()),
                    Endurance = Convert.ToInt32(reader[7].ToString()),
                    Wisdom = Convert.ToInt32(reader[8].ToString()),
                    Intelligence = Convert.ToInt32(reader[9].ToString()),
                    Charisma = Convert.ToInt32(reader[10].ToString()),
                    Species = Convert.ToString(reader[11].ToString()),
                    Class = Convert.ToString(reader[12].ToString()),
                    Item = Convert.ToString(reader[13].ToString()),
                    Abilities = Convert.ToString(reader[14].ToString()),
                    Ulta = Convert.ToString(reader[15].ToString()),
                    History = Convert.ToString(reader[16].ToString()),
                    Imag = Convert.ToString(reader[17].ToString()),
                    Arms = Convert.ToString(reader[18].ToString()),
                    Equip = Convert.ToString(reader[19].ToString()),
                    Description = Convert.ToString(reader[20].ToString()),
                    Passiv = Convert.ToInt32(reader[21].ToString())
                });
            }
            myConnect.Close();
            return Users;
        }

        
        public static ObservableCollection<NPCModel> ReadNPCInDb(string sql)
        {
            ObservableCollection<NPCModel> NPC = new ObservableCollection<NPCModel>();
            OleDbConnection myConnect = new OleDbConnection(constr);
            myConnect.Open();
            OleDbCommand myCommand = new OleDbCommand(sql, myConnect);
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                NPC.Add(new NPCModel()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    Name = Convert.ToString(reader[1].ToString()),
                    Notee = Convert.ToString(reader[2].ToString()),
                    Defence = Convert.ToInt32(reader[3].ToString()),
                    Health = Convert.ToInt32(reader[4].ToString()),
                    Power = Convert.ToInt32(reader[5].ToString()),
                    Dexterity = Convert.ToInt32(reader[6].ToString()),
                    Endurance = Convert.ToInt32(reader[7].ToString()),
                    Wisdom = Convert.ToInt32(reader[8].ToString()),
                    Intelligence = Convert.ToInt32(reader[9].ToString()),
                    Charisma = Convert.ToInt32(reader[10].ToString()),
                    Species = Convert.ToString(reader[11].ToString()),
                    Class = Convert.ToString(reader[12].ToString()),
                    Item = Convert.ToString(reader[13].ToString()),
                    Abilities = Convert.ToString(reader[14].ToString()),
                    Ulta = Convert.ToString(reader[15].ToString()),
                    History = Convert.ToString(reader[16].ToString()),
                    Imag = Convert.ToString(reader[17].ToString()),
                    Sounds = Convert.ToString(reader[18].ToString()),
                    RoomId = Convert.ToInt32(reader[19].ToString())
                });
            }
            myConnect.Close();
            return NPC;
        }
        public static void WriteBD(string _sql)
        {
                //string sql = "INSERT INTO `Orders` (`Customer`, `Count`, `DateOrder`, `DeidLine`) VALUES ('" + _customerText + "', '" + _count + "', '" + _dateOrder + "', '" + _daidLine + "')";
                OleDbConnection myConnect = new OleDbConnection(constr);
                myConnect.Open();
                OleDbCommand myCommand = new OleDbCommand(_sql, myConnect);
                myCommand.ExecuteReader();
                myConnect.Close();
        }
    }
}
