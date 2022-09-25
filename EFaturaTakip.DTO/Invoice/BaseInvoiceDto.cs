using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class BaseInvoiceDto
    {
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
    }
}
