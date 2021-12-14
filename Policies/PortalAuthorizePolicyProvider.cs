using System;
using System.Threading.Tasks;
using lab_authorize.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies
{
    public class PortalAuthorizePolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new AccountTokenRequirement(ValidationMode.Basic));  //account
            policy.AddRequirements(new UserTokenRequirement(ValidationMode.Basic));  //user
            return Task.FromResult(policy.Build());
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new AccountTokenRequirement(ValidationMode.Basic));  //account
            policy.AddRequirements(new UserTokenRequirement(ValidationMode.Basic));  //user
            return Task.FromResult(policy.Build());
        }

        // Policies are looked up by string name, so expect 'parameters' (like age)
        // to be embedded in the policy names. This is abstracted away from developers
        // by the more strongly-typed attributes derived from AuthorizeAttribute
        // (like [MinimumAgeAuthorize()] in this sample)
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(PortalAuthorizeConst.POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                var requires = policyName.Substring(PortalAuthorizeConst.POLICY_PREFIX.Length + 1).Split("_");

                policy.AddRequirements(new AccountTokenRequirement(Enum.Parse<ValidationMode>(requires[0].Split("=")[1])));  //account
                policy.AddRequirements(new UserTokenRequirement(Enum.Parse<ValidationMode>(requires[1].Split("=")[1])));  //user
                var permission = requires[2].Split("=")[1];
                if (string.IsNullOrWhiteSpace(permission) == false) 
                {
                    policy.AddRequirements(new PermissionRequirement(permission));  //permission
                }
                
                return Task.FromResult(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
