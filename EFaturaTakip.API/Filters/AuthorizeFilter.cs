using EFaturaTakip.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EFaturaTakip.API.Filters
{
    public class AuthorizeFilter : Attribute, IAuthorizationFilter
    {
        private readonly List<EnumUserType> _permissions;
        public AuthorizeFilter(EnumUserType[] permissions)
        {
            _permissions = new List<EnumUserType>();
            _permissions.AddRange(permissions);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Claims.Any())
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            bool isAuthorized = CheckUserPermission(context.HttpContext.User);
            if (!isAuthorized)
                context.Result = new ForbidResult();
        }
        private bool CheckUserPermission(ClaimsPrincipal user)
        {
            if (!user.Claims.Any(i => i.Type.Equals("UserType"))) return false;
            return _permissions.Contains(GetUserType(user));
        }

        private EnumUserType GetUserType(ClaimsPrincipal user)
        {
            int userType = int.Parse(user.Claims.First(i => i.Type.Equals("UserType")).Value);
            return (EnumUserType)userType;
        }
    }
}
