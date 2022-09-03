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
    public class InvoicesController : ControllerBase
    {
        private readonly UyumSoftClient _uyumSoftClient;

        private readonly IEMailSender _emailSender;
        private readonly UserInfo _userInfo;
        private readonly ICompanyDao _companyDao;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoicesController(UyumSoftClient uyumSoftClient, IEMailSender emailSender, ICompanyDao companyDao, IHttpContextAccessor httpContextAccessor)
        {
            _uyumSoftClient = uyumSoftClient;
            _emailSender = emailSender;
            _companyDao = companyDao;
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
        public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 700)
        {
            var result = await GetInboxInvoiceList(_userInfo);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value.Faturalar);
            return BadRequest(result.Data.Message);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.Accountant })]
        [HttpGet("GetInboxInvoiceListByCompanyId/{companyId}")]
        public async Task<IActionResult> GetListByCompanyId(Guid companyId, int pageIndex = 0, int pageSize = 700)
        {
            var serviceUserName = GetServiceUserName(companyId);
            var servicePassword = GetServiceUserPassword(companyId);
            if (string.IsNullOrWhiteSpace(serviceUserName) || string.IsNullOrWhiteSpace(servicePassword))
            {
                throw new ServiceUserNotFoundException("Servis login işlemi gerçekleştirilemedi.");
            }
            var userInfo = new UserInfo { Username = GetServiceUserName(companyId), Password = GetServiceUserPassword(companyId) };
            var result = await GetInboxInvoiceList(userInfo);
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value.Faturalar);
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

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Accountant, EnumUserType.Admin })]
        [HttpGet("ShowInvoice/{invoiceId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid invoiceId)
        {
            //company id gönder
            var result = await _uyumSoftClient.GetInboxInvoicePdf(invoiceId, _userInfo);
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

        private string GetServiceUserName(Guid companyId)
        {
            var company = _companyDao.Get(i => i.Id == companyId);
            return company?.ServiceUserName;

        }
        private string GetServiceUserPassword(Guid companyId)
        {
            var company = _companyDao.Get(i => i.Id == companyId);
            return company?.ServicePassword;
        }
        private Guid GetCompanyId()
        {
            var companyId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type.Equals("CompanyId"))?.Value;
            var result = Guid.TryParse(companyId, out Guid id);
            return result ? id : Guid.Empty;
        }

        private async Task<GetInboxInvoiceListResponse> GetInboxInvoiceList(UserInfo userInfo)
        {
            var result = await _uyumSoftClient.GetInboxInvoiceList(new Query
            {
                PageIndex = 0,
                PageSize = 700,
                CreateStartDate = DateTime.Now.AddDays(-15),
                CreateEndDate = DateTime.Now
            }, userInfo);
            return result;
        }
    }
}