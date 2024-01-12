using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Models
{
    public class EventsModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string TextEvent { get; set; }
        public string Sounds { get; set; }
        public string Images { get; set; }
        public int Order { get; set; }
    }
}
