using EFaturaTakip.API.UyumSoft;
using EFaturaTakip.DTO.UyumSoft;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly UyumSoftClient _uyumSoftClient;

        public InvoiceController(UyumSoftClient uyumSoftClient)
        {
            _uyumSoftClient = uyumSoftClient;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
