using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DTO.User;
using EFaturaTakip.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilter))]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public AuthenticationController(IConfiguration configuration, IUserManager userManager, IMapper mapper)
        {
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginDto loginModel)
        {
            var user = _userManager.GetUser(user => user.Phone.Equals(loginModel.PhoneNumber) && user.Password.Equals(loginModel.Password));
            if (user == null) return BadRequest("Kullanıcı adı veya şifre hatalı");
            var userInfo = _mapper.Map<UserInfoDto>(user);
            string token = CreateToken(loginModel, userInfo.Roles);
            userInfo.Token = token;
            userInfo.Expirytime = DateTime.Now.AddDays(1);//todo read expiration time form app settings
            user.LastLoginDate = DateTime.Now;
            _userManager.Update(user);
            return Ok(userInfo);
        }

        private string CreateToken(LoginDto loginModel, List<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.MobilePhone, loginModel.PhoneNumber),
                new Claim("ServiceUserName","Uyumsoft"), //todo: take service username password from current user
                new Claim("ServiceUserPassword","Uyumsoft")
            };

            AddRoleToClaims(claims, roles);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void AddRoleToClaims(List<Claim> claims, List<string> roles)
        {
            if (roles == null || !roles.Any()) return;
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, role));
            }
        }
    }
}
