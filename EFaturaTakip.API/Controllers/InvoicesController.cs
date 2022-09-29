using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Business.Concrete;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Invoice;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
    [ServiceFilter(typeof(ValidationFilter))]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly IInvoiceItemManager _invoiceItemManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoicesController(IInvoiceManager invoiceManager, IMapper mapper, IHttpContextAccessor httpContextAccessor, IInvoiceItemManager invoiceItemManager)
        {
            _invoiceManager = invoiceManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _invoiceItemManager = invoiceItemManager;
        }

        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var companyId = GetCurrentUserCompanyId();
            var invoiceList = _invoiceManager.GetAllWithFilter(i => i.CompanyId == companyId);
            var invoiceDtoList = _mapper.Map<List<InvoiceListDto>>(invoiceList);
            return Ok(invoiceDtoList);
        }
        [HttpGet("GetInvoice/{invoiceId}")]
        public IActionResult GetInvoice(Guid invoiceId)
        {
            var companyId = GetCurrentUserCompanyId();
            var invoice = _invoiceManager.GetAllWithFilter(i => i.CompanyId == companyId && i.Id == invoiceId).FirstOrDefault();
            if (invoice is null) return NotFound("Fatura bulunamadı.");
            var invoiceItemDto = _mapper.Map<InvoiceDto>(invoice);
            return Ok(invoiceItemDto);
        }

        [HttpGet("GetInvoiceItems/{invoiceId}")]
        public IActionResult GetInvoiceItems(Guid invoiceId)
        {
            var invoiceItemList = _invoiceItemManager.GetAllWithFilter(i => i.InvoiceId == invoiceId);
            var invoiceItemDtoList = _mapper.Map<List<InvoiceItemListDto>>(invoiceItemList);
            return Ok(invoiceItemDtoList);
        }

        [HttpPost("CreateInvoice")]
        public IActionResult Post([FromBody] InvoiceDto invoice)
        {
            var newInvoice = _mapper.Map<Invoice>(invoice);
            newInvoice.CompanyId = GetCurrentUserCompanyId();
            _invoiceManager.Create(newInvoice);
            return Ok("Fatura kaydedildi.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] InvoiceDto invoiceModel)
        {
            _invoiceManager.UpdateInvoiceWithItems(invoiceModel, id, GetCurrentUserCompanyId());
            return Ok("Fatura Güncellendi.");
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.TaxPayer })]
        [HttpDelete("delete/{invoiceId}")]
        public IActionResult Delete(Guid invoiceId)
        {
            var invoice = _invoiceManager.GetById(invoiceId);
            if (invoice == null) return BadRequest("Fatura bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _invoiceManager.Delete(invoice);
            return Ok("Fatura silindi.");
        }

        private Guid GetCurrentUserCompanyId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(c => c.Type.Equals("CompanyId")).Value);
        }
    }
}
