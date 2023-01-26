using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvoiceListDto : BaseInvoiceDto
    {
        public Guid InvoiceId { get; set; }
        public Guid EInvoiceId { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        public string EInvoiceNumber { get; set; }

        public bool IsConverted => EInvoiceId != Guid.Empty;
    }
}
