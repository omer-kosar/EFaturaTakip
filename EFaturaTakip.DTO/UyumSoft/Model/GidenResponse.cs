using Newtonsoft.Json;
using System.Collections.Generic;

namespace EFaturaTakip.DTO.UyumSoft.Model
{
    public class GidenResponse
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
    public class InvoiceIdentity : BaseData
    {
        public string id { get; set; }
        public string number { get; set; }
    }
    public partial class GidenInvoiceIdentitiesResponse
    {
        public aaaa Data { get; set; }
    }
    public partial class aaaa : BaseData
    {
        public InvoiceIdentity[] Value { get; set; }
    }
}
