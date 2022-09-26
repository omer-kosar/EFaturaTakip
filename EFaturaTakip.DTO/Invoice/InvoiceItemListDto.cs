using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvoiceItemListDto : BaseInvoiceItemDto
    {
        public Guid Id { get; set; }
        public string StockName { get; set; }
    }
}
