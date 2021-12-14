using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using lab_authorize.Policies;
using Microsoft.AspNetCore.Http;

namespace lab_authorize.Filters
{
    public class UserIdentiyMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdentiyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var claims = new List<Claim>();
            if (context.Request.Headers.TryGetValue(PortalAuthorizeConst.AccountTokenKey, out var accountToken))
                claims.Add(new Claim(PortalAuthorizeConst.AccountTokenKey, accountToken));

            if (context.Request.Headers.TryGetValue(PortalAuthorizeConst.UserTokenKey, out var userToken))
                claims.Add(new Claim(PortalAuthorizeConst.UserTokenKey, userToken));

            if (claims.Count > 0)
            {
                var identity = new ClaimsIdentity(claims, "tokens");
                context.User.AddIdentity(identity);
            }


            await _next(context);
        }
    }
}
