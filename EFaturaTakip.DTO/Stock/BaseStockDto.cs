using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Stock
{
    public class BaseStockDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("unit")]
        public int? Unit { get; set; }
        [JsonProperty("valueAddedTax")]
        public int ValueAddedTax { get; set; }
    }
}
