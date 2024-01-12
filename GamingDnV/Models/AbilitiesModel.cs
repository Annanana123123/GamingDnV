using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Models
{
    public class AbilitiesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notee { get; set; }
        public int IdPerson { get; set; }
        public int Enabled { get; set; }
        public int Order { get; set; }
    }
}
