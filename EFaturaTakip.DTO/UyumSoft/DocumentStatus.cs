using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class DocumentStatus
    {
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public Guid InvoiceId { get; set; }
        public string Message { get; set; }
    }
}
