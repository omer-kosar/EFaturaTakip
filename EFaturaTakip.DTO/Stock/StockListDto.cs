using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Stock
{
    public class StockListDto : BaseStockDto
    {
        [JsonProperty("unitDescription")]
        public string UnitDescription { get; set; }
        [JsonProperty("stockId")]
        public Guid StockId { get; set; }
    }
}
