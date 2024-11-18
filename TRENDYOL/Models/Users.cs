using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRENDYOL.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public ICollection<Baskets> Baskets { get; set; }
    }
}
