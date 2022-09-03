using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Stock;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilter))]
    [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]

    public class StocksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStockManager _stockManager;
        public StocksController(IMapper mapper, IStockManager stockManager)
        {
            _mapper = mapper;
            _stockManager = stockManager;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var stockList = _stockManager.GetAll(GetCurrentUserCompanyId());
            var stockDtoList = _mapper.Map<List<Stock>, List<StockListDto>>(stockList);
            return Ok(stockDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var stockItem = _stockManager.GetById(id);
            if (stockItem is null) return BadRequest("Stok bulunamadı.");
            var stockItemDto = _mapper.Map<StockAddDto>(stockItem);
            return Ok(stockItemDto);
        }

        [HttpPost("CreateStock")]
        public IActionResult Post([FromBody] StockAddDto stockModel)
        {
            var newStock = _mapper.Map<Stock>(stockModel);
            newStock.CompanyId = GetCurrentUserCompanyId();
            _stockManager.Create(newStock);
            return Ok("Stok kaydedildi.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] StockAddDto stockModel)
        {
            var updatedStock = _mapper.Map<Stock>(stockModel);
            updatedStock.Id = id;
            updatedStock.CompanyId = GetCurrentUserCompanyId();
            _stockManager.Update(updatedStock);
            return Ok("Stok güncellendi.");
        }

        [HttpDelete("delete/{stockId}")]
        public IActionResult Delete(Guid stockId)
        {
            var stock = _stockManager.GetById(stockId);
            if (stock == null) return BadRequest("Stok bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _stockManager.Delete(stock);
            return Ok("Stok silindi.");
        }

        private Guid GetCurrentUserCompanyId()
        {
            if (!HttpContext.User.Claims.Any(c => c.Type == "CompanyId")) return Guid.Empty;
            return Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CompanyId").Value);
        }
    }
}
