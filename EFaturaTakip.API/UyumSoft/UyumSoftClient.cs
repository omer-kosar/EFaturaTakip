using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.UyumSoft;
using EFaturaTakip.Exceptions.Invoice;
using Newtonsoft.Json;
using System.Text;

namespace EFaturaTakip.API.UyumSoft
{
    public class UyumSoftClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserInfo _userInfo;

        public UyumSoftClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _userInfo = new UserInfo
            {
                Username = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type.Equals("ServiceUserName"))?.Value,
                Password = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type.Equals("ServiceUserPassword"))?.Value
            };
        }

        public async Task<GetInboxInvoiceListResponse> GetInboxInvoiceList(Query query)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetInboxInvoiceList",
                parameters = new ParametersWithQuery
                {
                    query = query,
                    userInfo = _userInfo
                }
            };
            return await ApiCall<GetInboxInvoiceListResponse>(requestModel);
        }

        private async Task<SendDocumentResponse> SendDocumentResponse(List<DocumentResponseInfo> response)
        {
            var requestModel = new RequestParameters
            {
                Action = "SendDocumentResponse",
                parameters = new SendDocumentResponseParameters
                {
                    Responses = response,
                    userInfo = _userInfo
                }
            };
            return await ApiCall<SendDocumentResponse>(requestModel);
        }
        public async Task<SendDocumentResponse> ApproveInboxInvoiceList(List<Guid> invoiceIdList)
        {
            var documentResponseInfoList = CreateDocumentResponseList(invoiceIdList, DocumentResponseStatus.Approved);
            return await SendDocumentResponse(documentResponseInfoList);
        }

        public async Task<SendDocumentResponse> DeclineInboxInvoiceList(List<Guid> invoiceIdList)
        {
            var documentResponseInfoList = CreateDocumentResponseList(invoiceIdList, DocumentResponseStatus.Declined);
            return await SendDocumentResponse(documentResponseInfoList);
        }
        private List<DocumentResponseInfo> CreateDocumentResponseList(List<Guid> invoiceIdList, DocumentResponseStatus status)
        {
            if (!invoiceIdList.Any()) throw new InvoiceListEmptyException("İşlem yapmak istediğiniz fatura/faturaları seçiniz.");
            var documentResponseInfoList = new List<DocumentResponseInfo>();
            foreach (var invoiceId in invoiceIdList)
            {
                documentResponseInfoList.Add(new DocumentResponseInfo { InvoiceId = invoiceId.ToString(), ResponseStatus = status.ToString() });
            }
            return documentResponseInfoList;
        }
        private async Task<T> ApiCall<T>(RequestParameters requestModel)
        {
            var httpClient = _httpClientFactory.CreateClient("UyumSoftClient");
            var stringContent = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            var cntn = JsonConvert.SerializeObject(requestModel);
            var result = await httpClient.PostAsync("BasicIntegrationApi", stringContent);
            result.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
    }
}


