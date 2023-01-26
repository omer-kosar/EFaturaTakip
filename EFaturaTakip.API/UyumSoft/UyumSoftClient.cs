using EFaturaTakip.Common.Enums;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.DTO.UyumSoft;
using EFaturaTakip.DTO.UyumSoft.Model;
using EFaturaTakip.Exceptions.Invoice;
using Newtonsoft.Json;
using System.Text;

namespace EFaturaTakip.API.UyumSoft
{
    public class UyumSoftClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICompanyDao _companyDao;
        public UyumSoftClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetServiceUserName()
        {
            var company = _companyDao.Get(i => i.Id == GetCompanyId());
            return company?.ServiceUserName;

        }
        private string GetServiceUserPassword()
        {
            var company = _companyDao.Get(i => i.Id == GetCompanyId());
            return company?.ServicePassword;
        }
        private Guid GetCompanyId()
        {
            var companyId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type.Equals("CompanyId"))?.Value;
            var result = Guid.TryParse(companyId, out Guid id);
            return result ? id : Guid.Empty;
        }
        public async Task<GetInboxInvoiceListResponse> GetInboxInvoiceList(Query query, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetInboxInvoiceList",
                parameters = new ParametersWithQuery
                {
                    query = query,
                    userInfo = userInfo
                }
            };
            return await ApiCall<GetInboxInvoiceListResponse>(requestModel);
        }
        public async Task<GetInboxInvoiceListResponse> GetOutboxInvoiceList(Query query, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetOutboxInvoiceList",
                parameters = new ParametersWithQuery
                {
                    query = query,
                    userInfo = userInfo
                }
            };
            return await ApiCall<GetInboxInvoiceListResponse>(requestModel);
        }

        public async Task<InboxInviocePdfResponse> GetInboxInvoicePdf(Guid invoiceId, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetInboxInvoicePdf",
                parameters = new GetInboxInvoicePdfParameters
                {
                    InvoiceId = invoiceId.ToString(),
                    userInfo = userInfo
                }
            };
            return await ApiCall<InboxInviocePdfResponse>(requestModel);
        }
        public async Task<InboxInviocePdfResponse> GetOutboxInvoicePdf(Guid invoiceId, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetOutboxInvoicePdf",
                parameters = new GetInboxInvoicePdfParameters
                {
                    InvoiceId = invoiceId.ToString(),
                    userInfo = userInfo
                }
            };
            return await ApiCall<InboxInviocePdfResponse>(requestModel);
        }

        public async Task<SendDocumentResponse> ApproveInboxInvoiceList(List<Guid> invoiceIdList, UserInfo userInfo = null)
        {
            var documentResponseInfoList = CreateDocumentResponseList(invoiceIdList, DocumentResponseStatus.Approved);
            return await SendDocumentResponse(documentResponseInfoList, userInfo);
        }

        public async Task<SendDocumentResponse> DeclineInboxInvoiceList(List<Guid> invoiceIdList, UserInfo userInfo = null)
        {
            var documentResponseInfoList = CreateDocumentResponseList(invoiceIdList, DocumentResponseStatus.Declined);
            return await SendDocumentResponse(documentResponseInfoList, userInfo);
        }
        private async Task<SendDocumentResponse> SendDocumentResponse(List<DocumentResponseInfo> response, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "SendDocumentResponse",
                parameters = new SendDocumentResponseParameters
                {
                    Responses = response,
                    userInfo = userInfo
                }
            };
            return await ApiCall<SendDocumentResponse>(requestModel);
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
        public async Task<UserAliassesResponse> GetUserAliasses(string vknTckn, UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "GetUserAliasses",
                parameters = new IsEInvoiceUserParameters
                {
                    VknTckn = vknTckn,
                    userInfo = userInfo
                }
            };
            return await ApiCall<UserAliassesResponse>(requestModel);
        }
        public async Task<GidenInvoiceIdentitiesResponse> SendInvoice(List<GidenInvoiceInfo> invoices,UserInfo userInfo)
        {
            var requestModel = new RequestParameters
            {
                Action = "SendInvoice",
                parameters = new SendInvoiceParameters
                {
                    Invoices = invoices,
                    userInfo = userInfo
                }
            };
            var aa = await ApiCall<GidenInvoiceIdentitiesResponse>(requestModel);
            return aa;
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


