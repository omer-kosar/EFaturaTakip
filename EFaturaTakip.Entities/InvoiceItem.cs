using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities
{
    public class InvoiceItem
    {
        public Guid Id { get; set; }
        public Guid StockId { get; set; }
        public Guid InvoiceId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithTax { get; set; }
        public int Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public string? Comment { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
