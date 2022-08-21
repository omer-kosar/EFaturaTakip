using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.API.UyumSoft;
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
        private readonly UyumSoftClient _uyumSoftClient;
        public CompaniesController(ICompanyManager companyManager, IMapper mapper, UyumSoftClient uyumSoftClient)
        {
            _companyManager = companyManager;
            _mapper = mapper;
            _uyumSoftClient = uyumSoftClient;
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
        [HttpGet("getCompanyTitle")]
        public async Task<IActionResult> GetTitle(string vergiNo)
        {
            var result = await _uyumSoftClient.GetUserAliasses(vergiNo);
            if (result.Data.IsSucceded && result.Data.Value != null) return Ok(result.Data.Value.definition.title);
            return Ok("Unvan bulunamadı.");
        }
        [HttpGet("SearchCompany")]
        public IActionResult SearchCompany(string? name = "", int take = 20)
        {
            var result = _companyManager.SearchCompany(name, take);
            var companyListDto = _mapper.Map<List<CompanySearchDto>>(result);
            return Ok(companyListDto);
        }
    }
}
