using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AplicationServices.DTOs
{
    public class RouletteDto
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; } = string.Empty;
    }
}
