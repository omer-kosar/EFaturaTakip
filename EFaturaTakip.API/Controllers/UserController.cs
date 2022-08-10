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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserAddDto model)
        {
            var newUser = _mapper.Map<User>(model);
            _userManager.Create(newUser);
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}