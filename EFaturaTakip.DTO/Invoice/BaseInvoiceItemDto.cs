using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class BaseInvoiceItemDto
    {
        public Guid? StockId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithTax { get; set; }
        public int Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public string Comment { get; set; }
    }
}
