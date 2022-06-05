using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.Invoice
{
    public class InvioceEmailDto
    {
        //[JsonProperty("invoiceId")]
        //public Guid InvoiceId { get; set; }
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("eMailAdress")]
        public string? EMailAdress { get; set; }
    }
}
