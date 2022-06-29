using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DTO.Stock;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilter))]
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
            var stockList = _stockManager.GetAll();
            var stockDtoList = _mapper.Map<List<Stock>, List<StockListDto>>(stockList);
            return Ok(stockDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var stockItem = _stockManager.GetById(id);
            if (stockItem is null) return BadRequest("Stok bulunamadı.");
            return Ok(stockItem);
        }

        [HttpPost("CreateStock")]
        public IActionResult Post([FromBody] StockAddDto stockModel)
        {
            var newStock = _mapper.Map<Stock>(stockModel);
            _stockManager.Create(newStock);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] StockAddDto stockModel)
        {
            var updatedStock = _mapper.Map<Stock>(stockModel);
            updatedStock.Id = id;
            _stockManager.Update(updatedStock);
            return Ok("Stok güncellendi.");
        }

        [HttpDelete("delete/{stockId}")]
        public IActionResult Delete(Guid stockId)
        {
            var stock = _stockManager.GetById(stockId);
            if (stock == null) return BadRequest("Stok bulunamadı. Silme işlemi gerçekleştirilemiyor");
            _stockManager.Delete(stock);
            return Ok("Stok silindi.");
        }
    }
}
