using AutoMapper;
using EFaturaTakip.API.Filters;
using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DTO.Role;
using Microsoft.AspNetCore.Mvc;

namespace EFaturaTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeFilter(new EnumUserType[] { EnumUserType.Admin })]
    public class RolesController : ControllerBase
    {
        private readonly IRoleManager _roleManager;
        private readonly IMapper _mapper;

        public RolesController(IRoleManager roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roleList = _roleManager.GetAll();
            return Ok(_mapper.Map<List<RoleDto>>(roleList));
        }
    }
}
