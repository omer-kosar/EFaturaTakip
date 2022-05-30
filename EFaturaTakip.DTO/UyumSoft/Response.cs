using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.DTO.UyumSoft
{
    public class BaseResponse
    {
        public object ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public int JsonRequestBehavior { get; set; }
        public long MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }
    public class BaseData
    {
        public bool IsSucceded { get; set; }
        public string Message { get; set; }
    }
    public class GetInboxInvoiceListResponse : BaseResponse
    {
        public GetInboxInvoiceList Data { get; set; }
    }


    public class GetInboxInvoiceList : BaseData
    {
        [JsonProperty("Value")]
        public GetInboxInvoiceListValue Value { get; set; }
    }
    public class GetInboxInvoiceListValue
    {
        [JsonProperty("Items")]
        public List<EFatura> Faturalar { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }

    public class IsEInvioceUserResponse : BaseResponse
    {
        [JsonProperty("Data")]
        public IsEInvioceUserData Data { get; set; }
    }
    public class IsEInvioceUserData : BaseData
    {
        [JsonProperty("Value")]
        public bool IsEInvoiceUser { get; set; }
    }

    public class InboxInviocePdfResponse : BaseResponse
    {
        [JsonProperty("Data")]
        public InboxInviocePdfData Data { get; set; }
    }
    public class InboxInviocePdfData : BaseData
    {
        [JsonProperty("Value")]
        public InboxInviocePdfDataValue Value { get; set; }
    }
    public class InboxInviocePdfDataValue
    {
        [JsonProperty("Data")]
        public byte[] InvoicePdfAsByte { get; set; }
    }

    public class SendDocumentResponse : BaseResponse
    {
        [JsonProperty("Data")]
        public SendDocumentResponseData Data { get; set; }
    }
    public class SendDocumentResponseData : BaseData
    {
        [JsonProperty("Value")]
        public bool InvoiceApproveDeclineResult { get; set; }
    }
    public class QueryDocumentResponseStatus : BaseResponse
    {
        [JsonProperty("Data")]
        public QueryDocumentResponseStatusData Data { get; set; }
    }
    public class QueryDocumentResponseStatusData : BaseData
    {
        [JsonProperty("Value")]
        public List<DocumentStatus> Value { get; set; }

    }
}
