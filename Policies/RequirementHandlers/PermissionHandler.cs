using System.Threading.Tasks;
using lab_authorize.Filters;
using lab_authorize.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.RequirementHandlers
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (string.IsNullOrWhiteSpace(requirement.Action))
            { 
                context.Succeed(requirement); 
            }
            else
            {
                if (context.User.HasClaim(f => f.Type == PortalAuthorizeConst.UserTokenKey && f.Value == "admin"))
                    context.Succeed(requirement);
                else
                    context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
