using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.API.UyumSoft;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Company;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CompaniesController(ICompanyManager companyManager, IMapper mapper, UyumSoftClient uyumSoftClient, IHttpContextAccessor httpContextAccessor)
        {
            _companyManager = companyManager;
            _mapper = mapper;
            _uyumSoftClient = uyumSoftClient;
            _httpContextAccessor = httpContextAccessor;
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.Accountant })]
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var companyList = _companyManager.GetAllWithFilter(i => i.CompanySaveType == (int)EnumCompanySaveType.CompanyUsingProgram);
            var companyDtoList = _mapper.Map<List<Company>, List<CompanyListDto>>(companyList);
            return Ok(companyDtoList);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]

        [HttpGet("GetCustomerList")]
        public IActionResult GetCustomerList()
        {
            var companyList = _companyManager.GetAllWithFilter(i => i.CompanySaveType == (int)EnumCompanySaveType.Customer);
            var companyDtoList = _mapper.Map<List<Company>, List<CompanyListDto>>(companyList);
            return Ok(companyDtoList);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var companyItem = _companyManager.GetById(id);
            if (companyItem is null) return BadRequest("Firma bulunamadı.");
            var companyItemDto = _mapper.Map<CompanyAddDto>(companyItem);
            return Ok(companyItemDto);
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.TaxPayer })]

        [HttpPost("CreateCompany")]
        public IActionResult Post([FromBody] CompanyAddDto companyModel)
        {
            bool currentUserIsAdmin = CurrentUserIsAdmin();

            if (!currentUserIsAdmin)
                companyModel.CompanyId = GetCurrentUserCompanyId();

            var newCompany = _mapper.Map<Company>(companyModel);
            newCompany.CompanySaveType = currentUserIsAdmin ? (int)EnumCompanySaveType.CompanyUsingProgram : (int)EnumCompanySaveType.Customer;
            _companyManager.Create(newCompany);
            return Ok("Firma Kaydedildi.");
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.TaxPayer })]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CompanyAddDto companyModel)
        {
            var updatedCompany = _mapper.Map<Company>(companyModel);
            updatedCompany.Id = id;
            bool currentUserIsAdmin = CurrentUserIsAdmin();
            if (!currentUserIsAdmin)
            {
                companyModel.CompanyId = GetCurrentUserCompanyId();
            }
            updatedCompany.CompanySaveType = currentUserIsAdmin ? (int)EnumCompanySaveType.CompanyUsingProgram : (int)EnumCompanySaveType.Customer;
            _companyManager.Update(updatedCompany);
            return Ok("Firma güncellendi.");
        }
        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.TaxPayer })]
        [HttpDelete("delete/{companyId}")]
        public IActionResult Delete(Guid companyId)
        {
            var stock = _companyManager.GetById(companyId);
            if (stock == null) return BadRequest("Firma bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _companyManager.Delete(stock);
            return Ok("Firma silindi.");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer })]
        [HttpGet("getCompanyTitle")]
        public async Task<IActionResult> GetTitle(string vergiNo)
        {
            var result = await _uyumSoftClient.GetUserAliasses(vergiNo);
            if (result.Data.IsSucceded && result.Data.Value != null) return Ok(result.Data.Value.definition.title);
            return Ok("Unvan bulunamadı.");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.TaxPayer, EnumUserType.Admin, EnumUserType.Accountant })]
        [HttpGet("SearchCompany")]
        public IActionResult SearchCompany(string? name = "", int take = 20)
        {
            var result = _companyManager.SearchCompany(name, take);
            var companyListDto = _mapper.Map<List<CompanySearchDto>>(result);
            return Ok(companyListDto);
        }
        private Guid GetCurrentUserCompanyId()
        {
            return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(c => c.Type.Equals("CompanyId")).Value);
        }
        private bool CurrentUserIsAdmin()
        {
            int userType = int.Parse(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type.Equals("UserType")).Value);
            return userType == (int)EnumUserType.Admin;
        }
    }
}
