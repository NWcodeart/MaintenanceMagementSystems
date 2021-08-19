using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaintenanceMagementSystems.API.Filters
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            var token =!String.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"])?
               context.HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString().Remove(0, 7)  : "";

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var jti = tokenS.Claims;
                var identity = context.HttpContext.User.Identity as ClaimsIdentity;
                identity.AddClaims(jti);
            }
           
        }

    }
}
