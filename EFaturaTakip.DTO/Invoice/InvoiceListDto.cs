using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvoiceListDto : BaseInvoiceDto
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }
}
