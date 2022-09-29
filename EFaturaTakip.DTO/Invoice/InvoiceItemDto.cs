using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvoiceItemDto : BaseInvoiceItemDto
    {
        public Guid Id { get; set; }
        public Guid? StockId { get; set; }
        public Guid InvoiceId { get; set; }
    }
}
