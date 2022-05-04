using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Models
{
    public class ItemsModel
    {
        //ID
        public int Id { get; set; }
        //Название предмета
        public string Name { get; set; }
        //Описание
        public string Notee { get; set; }
        //Id владельца
        public int IdPerson { get; set; }
        //Вид владельца
        public int Person { get; set; }
        //Количество
        public int Count { get; set; }
        public string Imag { get; set; }
    }
}
