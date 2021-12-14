using System.Threading.Tasks;
using lab_authorize.Filters;
using lab_authorize.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.RequirementHandlers
{
    public class UserTokenHandler : AuthorizationHandler<UserTokenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTokenRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == PortalAuthorizeConst.UserTokenKey))
            {
                //驗證過期
                //.....

                if (requirement.Mode == ValidationMode.Fully) 
                {
                    //fully mode validation
                }

                context.Succeed(requirement);
            }
            else 
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
