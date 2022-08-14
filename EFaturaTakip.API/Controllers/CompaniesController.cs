using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DTO.Company;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilter))]
    public class CompaniesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyManager _companyManager;

        public CompaniesController(ICompanyManager companyManager, IMapper mapper)
        {
            _companyManager = companyManager;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var companyList = _companyManager.GetAll();
            var companyDtoList = _mapper.Map<List<Company>, List<CompanyListDto>>(companyList);
            return Ok(companyDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var companyItem = _companyManager.GetById(id);
            if (companyItem is null) return BadRequest("Firma bulunamadı.");
            var companyItemDto = _mapper.Map<CompanyAddDto>(companyItem);
            return Ok(companyItemDto);
        }

        [HttpPost("CreateCompany")]
        public IActionResult Post([FromBody] CompanyAddDto companyModel)
        {
            var newCompany = _mapper.Map<Company>(companyModel);
            _companyManager.Create(newCompany);
            return Ok("Firma Kaydedildi.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CompanyAddDto companyModel)
        {
            var updatedCompany = _mapper.Map<Company>(companyModel);
            updatedCompany.Id = id;
            _companyManager.Update(updatedCompany);
            return Ok("Firma güncellendi.");
        }

        [HttpDelete("delete/{companyId}")]
        public IActionResult Delete(Guid companyId)
        {
            var stock = _companyManager.GetById(companyId);
            if (stock == null) return BadRequest("Firma bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _companyManager.Delete(stock);
            return Ok("Firma silindi.");
        }
    }
}
