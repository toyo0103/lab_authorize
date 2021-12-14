using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.Requirements
{
    public class AccountTokenRequirement : IAuthorizationRequirement
    {
        public readonly ValidationMode Mode;

        public AccountTokenRequirement(ValidationMode mode) 
        {
            this.Mode = mode;
        }
    }
}
