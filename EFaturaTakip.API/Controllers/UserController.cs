using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
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
        public UserController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var userList = _userManager.GetAll();
            var userDtoList = _mapper.Map<List<User>, List<UserListDto>>(userList);
            return Ok(userDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var userItem = _userManager.GetUser(i => i.Id == id);
            if (userItem is null) return BadRequest("Kullanıcı bulunamadı.");
            var userItemDto = _mapper.Map<UserUpdateDto>(userItem);
            return Ok(userItemDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserAddDto model)
        {
            var newUser = _mapper.Map<User>(model);
            _userManager.Create(newUser);
            return Ok("Kullanıcı Kaydedildi.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UserUpdateDto userModel)
        {
            var updatedUser = _mapper.Map<User>(userModel);
            updatedUser.Id = id;
            _userManager.UpdateWithRoles(updatedUser, userModel.Roles.Select(i => i.Id).ToList());
            return Ok("Kullanıcı güncellendi.");
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult Delete(Guid userId)
        {
            var user = _userManager.GetUser(i => i.Id == userId);
            if (user is null) return BadRequest("Kullanıcı bulunamadı. Silme işlemi gerçekleştirilemiyor.");
            _userManager.Delete(user);
            return Ok("Kullanıcı silindi.");
        }
    }
}