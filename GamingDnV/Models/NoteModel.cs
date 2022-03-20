using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Models
{
    public class NoteModel
    {
        //ID
        public int Id { get; set; }
        //Название заметки
        public string Name { get; set; }
        //Заметка
        public string Notee { get; set; }
        //Id Истории
        public int HistoryId { get; set; }
    }
}
