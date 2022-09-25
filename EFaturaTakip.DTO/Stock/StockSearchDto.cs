using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Stock
{
    public class StockSearchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Tax { get; set; }

        public decimal Price { get; set; }
    }
}
