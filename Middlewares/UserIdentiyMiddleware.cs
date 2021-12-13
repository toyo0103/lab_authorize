using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
            
            if(context.Request.Headers.TryGetValue("Authorization",out var token) &&
                token == "123")
            {   
                    Console.WriteLine("123");
                    //創建一個身份認證
                    var claims = new List<Claim>() {
                    new Claim(MyClaimTypes.Permission,"CanReadResource"), //用戶ID
                    }; 

                    var identity = new ClaimsIdentity(claims, "TestLogin");
                    // var userPrincipal = new ClaimsPrincipal(identity);
                    context.User.AddIdentity(identity);
            }
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
