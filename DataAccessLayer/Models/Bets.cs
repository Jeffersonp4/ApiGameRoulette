using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Bets
    {
        public int id { get; set; }
        public int userid { get; set; }

        public decimal betamount { get; set; }

        public string bettype { get; set; } = null!;

        public string betvalue { get; set; } = null!;

        public DateTime date { get; set; }
        public Users Users { get; set; } = null!;

        public Results Result { get; set; } = null!;
    }
}
