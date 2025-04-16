using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using DataAccessLayer.Models;

namespace AplicationServices.DTOs
{
    public class BetDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("bet_amount")]
        public decimal BetAmount { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; } = string.Empty;

        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonPropertyName("bet_type")]
        public BetTypeEnum BetType { get; set; }
        [JsonPropertyName("bet_value")]
        public string BetValue { get; set; } = null!;

        [JsonPropertyName("amount_win")]
        public decimal AmountWin { get; set; }
        [JsonPropertyName("result")]
        public bool Result { get; set; }
    }
}
