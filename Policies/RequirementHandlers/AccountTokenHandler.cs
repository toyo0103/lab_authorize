﻿using System.Threading.Tasks;
using lab_authorize.Filters;
using lab_authorize.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.RequirementHandlers
{
    public class AccountTokenHandler : AuthorizationHandler<AccountTokenRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountTokenRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == PortalAuthorizeConst.AccountTokenKey))
            {
                //驗證過其

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
