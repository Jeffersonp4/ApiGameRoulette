using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Results
    {
        public int id { get; set; }

        public int betId { get; set; }
        public int randomroulette { get; set; }
        public string colorroulette { get; set; } = null!;

        public bool result { get; set; }
        public decimal prizeamount { get; set; }

        public Bets Bet { get; set; } = null!;
    }
}
