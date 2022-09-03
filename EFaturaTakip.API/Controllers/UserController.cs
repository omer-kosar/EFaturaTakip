using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilter))]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserManager userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var userList = _userManager.GetAll();
            var userDtoList = _mapper.Map<List<User>, List<UserListDto>>(userList);
            return Ok(userDtoList);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var userItem = _userManager.GetUser(i => i.Id == id);
            if (userItem is null) return BadRequest("Kullanıcı bulunamadı.");
            var userItemDto = _mapper.Map<UserUpdateDto>(userItem);
            return Ok(userItemDto);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpPost]
        public IActionResult Post([FromBody] UserAddDto model)
        {
            var newUser = _mapper.Map<User>(model);
            _userManager.Create(newUser);
            return Ok("Kullanıcı Kaydedildi.");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UserUpdateDto userModel)
        {
            var updatedUser = _mapper.Map<User>(userModel);
            updatedUser.Id = id;
            _userManager.UpdateWithRoles(updatedUser, userModel.Roles.Select(i => i.Id).ToList());
            return Ok("Kullanıcı güncellendi.");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpDelete("delete/{userId}")]
        public IActionResult Delete(Guid userId)
        {
            var user = _userManager.GetUser(i => i.Id == userId);
            if (user is null) return BadRequest("Kullanıcı bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _userManager.Delete(user);
            return Ok("Kullanıcı silindi.");
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpGet("searchfinancialadvisor")]
        public IActionResult SearchFinancialAdvisor(string? name = "", int take = 20)
        {
            var result = _userManager.SearchFinancialAdvisor(name, take);
            var financialAdvisorListDto = _mapper.Map<List<FinancialAdvisorSearchDto>>(result);
            return Ok(financialAdvisorListDto);
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
        [HttpGet("ChangeFinancialAdvisor")]
        public IActionResult ChangeFinancialAdvisor(Guid advisorId, Guid companyId)
        {
            _userManager.ChangeAdvisor(advisorId, companyId);
            return Ok();
        }

        [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin, EnumUserType.Accountant, EnumUserType.TaxPayer })]
        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var authenticatedUserId = GetAuthenticatedUserId();
            if (authenticatedUserId != changePasswordDto.Id)
                return BadRequest("Şifre değiştirme işlemi gerçekleştirilemiyor.");

            var user = _userManager.GetUser(i => i.Id == changePasswordDto.Id);
            user.Password = changePasswordDto.NewPassword;
            _userManager.Update(user);
            return Ok("Şifre değiştirildi. Yeni şifrenizle tekra giriş yapınız.");
        }

        private Guid GetAuthenticatedUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type.Equals("UserId")).Value;
            return Guid.Parse(userId);
        }
    }
}