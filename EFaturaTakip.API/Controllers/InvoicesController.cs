using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Business.Concrete;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Invoice;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
    [ServiceFilter(typeof(ValidationFilter))]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoicesController(IInvoiceManager invoiceManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _invoiceManager = invoiceManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/<InvoiceController>/5
        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var companyId = GetCurrentUserCompanyId();
            var invoiceList = _invoiceManager.GetAllWithFilter(i => i.CompanyId == companyId);
            var invoiceDtoList = _mapper.Map<List<InvoiceListDto>>(invoiceList);
            return Ok(invoiceDtoList);
        }

        // POST api/<InvoiceController>
        [HttpPost("CreateInvoice")]
        public IActionResult Post([FromBody] InvoiceDto invoice)
        {
            var newInvoice = _mapper.Map<Invoice>(invoice);
            newInvoice.CompanyId = GetCurrentUserCompanyId();
            _invoiceManager.Create(newInvoice);
            return Ok("Fatura kaydedildi.");
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


        private Guid GetCurrentUserCompanyId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(c => c.Type.Equals("CompanyId")).Value);
        }
    }
}
