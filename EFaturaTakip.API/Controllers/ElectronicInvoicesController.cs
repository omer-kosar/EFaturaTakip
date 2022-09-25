using EFaturaTakip.API.Filters;
using EFaturaTakip.API.UyumSoft;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.EMail;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.DTO.Invoice;
using EFaturaTakip.DTO.UyumSoft;
using EFaturaTakip.Exceptions.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(ValidationFilter))]
    public class ElectronicInvoicesController : ControllerBase
    {
        private readonly UyumSoftClient _uyumSoftClient;

        private readonly IEMailSender _emailSender;
        private readonly UserInfo _userInfo;
        private readonly ICompanyManager _companyManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ElectronicInvoicesController(UyumSoftClient uyumSoftClient, IEMailSender emailSender, ICompanyManager companyManager, IHttpContextAccessor httpContextAccessor)
        {
            _uyumSoftClient = uyumSoftClient;
            _emailSender = emailSender;
            _companyManager = companyManager;
            _httpContextAccessor = httpContextAccessor;

            Guid companyId = GetCompanyId();
            _userInfo = new UserInfo
            {
                Username = GetServiceUserName(companyId),
                Password = GetServiceUserPassword(companyId)
            };
        }

        [HttpGet("InboxInvoiceList")]
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
        public async Task<IActionResult> Get(DateTime? baslangicTarihi, DateTime? bitisTarihi,
            int pageIndex = 0, int pageSize = 10)
        {
            var result = await GetInboxInvoiceList(_userInfo, baslangicTarihi, bitisTarihi, pageIndex, pageSize);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value);
            return BadRequest(result.Data.Message);
        }
        [HttpGet("OutboxInvoiceList")]
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
        public async Task<IActionResult> GetOutboxInvoiceList(DateTime? baslangicTarihi, DateTime? bitisTarihi,
            int pageIndex = 0, int pageSize = 10)
        {
            var result = await GetOutboxInvoiceList(_userInfo, baslangicTarihi, bitisTarihi, pageIndex, pageSize);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value);
            return BadRequest(result.Data.Message);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.Accountant })]
        [HttpGet("GetInboxInvoiceListByCompanyId/{companyId}")]
        public async Task<IActionResult> GetListByCompanyId(Guid companyId, DateTime? baslangicTarihi, DateTime? bitisTarihi, int pageIndex = 0, int pageSize = 10)
        {
            var serviceUserName = GetServiceUserName(companyId);
            var servicePassword = GetServiceUserPassword(companyId);
            if (string.IsNullOrWhiteSpace(serviceUserName) || string.IsNullOrWhiteSpace(servicePassword))
            {
                throw new ServiceUserNotFoundException("Servis login işlemi gerçekleştirilemedi.");
            }
            var userInfo = new UserInfo { Username = serviceUserName, Password = servicePassword };
            var result = await GetInboxInvoiceList(userInfo, baslangicTarihi, bitisTarihi, pageIndex, pageSize);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value);
            return BadRequest(result.Data.Message);
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.Accountant })]
        [HttpGet("GetOutboxInvoiceListByCompanyId/{companyId}")]
        public async Task<IActionResult> GetOutboxInvoiceListByCompanyId(Guid companyId, DateTime? baslangicTarihi, DateTime? bitisTarihi, int pageIndex = 0, int pageSize = 10)
        {
            var serviceUserName = GetServiceUserName(companyId);
            var servicePassword = GetServiceUserPassword(companyId);
            if (string.IsNullOrWhiteSpace(serviceUserName) || string.IsNullOrWhiteSpace(servicePassword))
            {
                throw new ServiceUserNotFoundException("Servis login işlemi gerçekleştirilemedi.");
            }
            var userInfo = new UserInfo { Username = serviceUserName, Password = servicePassword };
            var result = await GetOutboxInvoiceList(userInfo, baslangicTarihi, bitisTarihi, pageIndex, pageSize);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value);
            return BadRequest(result.Data.Message);
        }


        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Accountant })]
        [HttpPost("ApproveInboxInvoices")]
        public async Task<IActionResult> ApproveInboxInvoices(List<Guid> invoiceIdList)
        {
            if (invoiceIdList == null || !invoiceIdList.Any()) return BadRequest("Onaylamak istediğiniz faturaları seçiniz.");
            var result = await _uyumSoftClient.ApproveInboxInvoiceList(invoiceIdList, _userInfo);
            if (result.Data.IsSucceded)
                return Ok("Seçmiş olduğunuz faturalar onaylandı.");
            return BadRequest(result.Data.Message);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Accountant })]
        [HttpPost("DeclineInboxInvoices")]
        public async Task<IActionResult> DeclineInboxInvoices(List<Guid> invoiceIdList)
        {
            if (invoiceIdList == null || !invoiceIdList.Any()) return BadRequest("Onaylamak istediğiniz faturaları seçiniz.");
            var result = await _uyumSoftClient.DeclineInboxInvoiceList(invoiceIdList, _userInfo);
            if (result.Data.IsSucceded)
                return Ok("Seçmiş olduğunuz faturalar reddedildi.");
            return BadRequest(result.Data.Message);
        }

        [HttpGet("ShowInvoice/{invoiceId}/{companyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid invoiceId, Guid companyId)
        {
            var userInfo = new UserInfo { Username = GetServiceUserName(companyId), Password = GetServiceUserPassword(companyId) };
            var result = await _uyumSoftClient.GetInboxInvoicePdf(invoiceId, userInfo);
            if (!result.Data.IsSucceded)
                return BadRequest(result.Data.Message);

            return new FileContentResult(result.Data.Value.InvoicePdfAsByte, "application/pdf");
        }
        [HttpGet("ShowOutBoxInvoice/{invoiceId}/{companyId}")]
        [AllowAnonymous]
        public async Task<IActionResult> ShowOutBoxInvoice(Guid invoiceId, Guid companyId)
        {
            var userInfo = new UserInfo { Username = GetServiceUserName(companyId), Password = GetServiceUserPassword(companyId) };
            var result = await _uyumSoftClient.GetOutboxInvoicePdf(invoiceId, userInfo);
            if (!result.Data.IsSucceded)
                return BadRequest(result.Data.Message);

            return new FileContentResult(result.Data.Value.InvoicePdfAsByte, "application/pdf");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Accountant, EnumUserType.Admin })]
        [HttpPost("SendMail/{invoiceId}")]
        public async Task<IActionResult> Post([FromRoute] Guid invoiceId, [FromBody] InvioceEmailDto emailModel)
        {
            var result = await _uyumSoftClient.GetInboxInvoicePdf(invoiceId, _userInfo);
            if (!result.Data.IsSucceded) return BadRequest(result.Data.Message);
            var message = new EMailMessage(new string[] { emailModel.EMailAdress }, "Test email async", "This is the content from our async email.", new EMailAttachment("application/pdf", "fatura", result.Data.Value.InvoicePdfAsByte));
            await _emailSender.SendEmailAsync(message);
            return Ok("Fatura mail olarak gönderildi");
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Accountant, EnumUserType.Admin })]
        [HttpPost("SendOutBoxInvoiceMail/{invoiceId}")]
        public async Task<IActionResult> SendOutBoxInvoiceMail([FromRoute] Guid invoiceId, [FromBody] InvioceEmailDto emailModel)
        {
            var result = await _uyumSoftClient.GetOutboxInvoicePdf(invoiceId, _userInfo);
            if (!result.Data.IsSucceded) return BadRequest(result.Data.Message);
            var message = new EMailMessage(new string[] { emailModel.EMailAdress }, "Test email async", "This is the content from our async email.", new EMailAttachment("application/pdf", "fatura", result.Data.Value.InvoicePdfAsByte));
            await _emailSender.SendEmailAsync(message);
            return Ok("Fatura mail olarak gönderildi");
        }

        private string GetServiceUserName(Guid companyId)
        {
            var company = _companyManager.GetById(companyId);
            return company?.ServiceUserName;

        }
        private string GetServiceUserPassword(Guid companyId)
        {
            var company = _companyManager.GetById(companyId);
            return company?.ServicePassword;
        }
        private Guid GetCompanyId()
        {
            var companyId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type.Equals("CompanyId"))?.Value;
            var result = Guid.TryParse(companyId, out Guid id);
            return result ? id : Guid.Empty;
        }

        private async Task<GetInboxInvoiceListResponse> GetInboxInvoiceList(UserInfo userInfo, DateTime? baslangicTarihi, DateTime? bitisTarihi, int pageIndex = 0, int pageSize = 10)
        {
            var result = await _uyumSoftClient.GetInboxInvoiceList(new Query
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                CreateStartDate = baslangicTarihi ?? DateTime.Now.AddDays(-60),
                CreateEndDate = bitisTarihi ?? DateTime.Now
            }, userInfo);
            return result;
        }
        private async Task<GetInboxInvoiceListResponse> GetOutboxInvoiceList(UserInfo userInfo, DateTime? baslangicTarihi, DateTime? bitisTarihi, int pageIndex = 0, int pageSize = 10)
        {
            var result = await _uyumSoftClient.GetOutboxInvoiceList(new Query
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                CreateStartDate = baslangicTarihi ?? DateTime.Now.AddDays(-60),
                CreateEndDate = bitisTarihi ?? DateTime.Now
            }, userInfo);
            return result;
        }

    }
}