using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class RequestParameters
    {
        public string Action { get; set; }
        public BaseParameters parameters { get; set; }
    }
    public class UserInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Query
    {
        public DateTime CreateStartDate { get; set; }
        public DateTime CreateEndDate { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class BaseParameters
    {
        public UserInfo userInfo { get; set; }
    }
    public class ParametersWithQuery : BaseParameters
    {
        public Query query { get; set; }
    }

    public class IsEInvoiceUserParameters : BaseParameters
    {
        [JsonProperty("vknTckn")]
        public string VknTckn { get; set; }
    }
    public class GetInboxInvoicePdfParameters : BaseParameters
    {
        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }
    }
    public class GetInboxInvoiceParameters : BaseParameters
    {
        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }
    }
    public class SendDocumentResponseParameters : BaseParameters
    {
        [JsonProperty("responses")]
        public List<DocumentResponseInfo> Responses { get; set; }
    }
    public class QueryDocumentResponseStatusParameters : BaseParameters
    {
        [JsonProperty("invoiceIds")]
        public List<string> InvoiceIds { get; set; }
    }

}
