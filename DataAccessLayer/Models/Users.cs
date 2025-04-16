using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Users
    {
        public int id { get; set; }
        public required string name { get; set; } = null!;
        public decimal balance { get; set; }

        public ICollection<Bets> Bets { get; set; } = new List<Bets>();
    }
}
