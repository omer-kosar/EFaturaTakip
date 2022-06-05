using EFaturaTakip.API.Filters;
using EFaturaTakip.API.UyumSoft;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.EMail;
using EFaturaTakip.DTO.Invoice;
using EFaturaTakip.DTO.UyumSoft;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(ValidationFilter))]
    public class InvoiceController : ControllerBase
    {
        private readonly IUserManager _userManager;

        private readonly UyumSoftClient _uyumSoftClient;

        private readonly IEMailSender _emailSender;

        public InvoiceController(UyumSoftClient uyumSoftClient, IUserManager userManager, IEMailSender emailSender)
        {
            _uyumSoftClient = uyumSoftClient;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: api/<InvoiceController>
        [HttpGet("InboxInvoiceList")]
        public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 700)
        {
            var result = await _uyumSoftClient.GetInboxInvoiceList(new Query { PageIndex = pageIndex, PageSize = pageSize, CreateStartDate = DateTime.Now.AddDays(-15), CreateEndDate = DateTime.Now });
            if (result.Data.IsSucceded)
                return Ok(result.Data.Value.Faturalar);
            return BadRequest(result.Data.Message);
        }

        [HttpPost("ApproveInboxInvoices")]
        public async Task<IActionResult> ApproveInboxInvoices(List<Guid> invoiceIdList)
        {
            if (invoiceIdList == null || !invoiceIdList.Any()) return BadRequest("Onaylamak istediğiniz faturaları seçiniz.");
            var result = await _uyumSoftClient.ApproveInboxInvoiceList(invoiceIdList);
            if (result.Data.IsSucceded)
                return Ok("Seçmiş olduğunuz faturalar onaylandı.");
            return BadRequest(result.Data.Message);
        }

        [HttpPost("DeclineInboxInvoices")]
        public async Task<IActionResult> DeclineInboxInvoices(List<Guid> invoiceIdList)
        {
            if (invoiceIdList == null || !invoiceIdList.Any()) return BadRequest("Onaylamak istediğiniz faturaları seçiniz.");
            var result = await _uyumSoftClient.DeclineInboxInvoiceList(invoiceIdList);
            if (result.Data.IsSucceded)
                return Ok("Seçmiş olduğunuz faturalar reddedildi.");
            return BadRequest(result.Data.Message);
        }
        // GET api/<InvoiceController>/5
        [HttpGet("ShowInvoice/{invoiceId}/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid invoiceId, Guid id)
        {

            var user = _userManager.GetUser(i => i.Id == id);
            if (user == null) return BadRequest("Fatura şu an görüntülenemiyor.");
            var result = await _uyumSoftClient.GetInboxInvoicePdf(invoiceId, new UserInfo { Username = user.ServiceUserName, Password = user.ServicePassword });
            if (!result.Data.IsSucceded)
                return BadRequest(result.Data.Message);

            return new FileContentResult(result.Data.Value.InvoicePdfAsByte, "application/pdf");
        }

        [HttpPost("SendMail/{invoiceId}")]
        public async Task<IActionResult> Post([FromRoute] Guid invoiceId, [FromBody] InvioceEmailDto emailModel)
        {
            var user = _userManager.GetUser(i => i.Id == emailModel.UserId);
            if (user == null) return BadRequest("Fatura şu an mail olarak gönderilemiyor.");
            var result = await _uyumSoftClient.GetInboxInvoicePdf(invoiceId, new UserInfo { Username = user.ServiceUserName, Password = user.ServicePassword });
            if (!result.Data.IsSucceded) return BadRequest(result.Data.Message);
            var message = new EMailMessage(new string[] { emailModel.EMailAdress }, "Test email async", "This is the content from our async email.", new EMailAttachment("application/pdf", "fatura", result.Data.Value.InvoicePdfAsByte));
            await _emailSender.SendEmailAsync(message);
            return Ok("Fatura mail olarak gönderildi");
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}