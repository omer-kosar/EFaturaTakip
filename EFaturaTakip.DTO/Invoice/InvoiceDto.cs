using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvoiceDto : BaseInvoiceDto
    {
        public Guid CustomerId { get; set; }
        public List<InvoiceItemDto> InvoiceItems { get; set; }
    }
}
