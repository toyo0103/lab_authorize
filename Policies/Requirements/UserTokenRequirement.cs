using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.Requirements
{
    public class UserTokenRequirement : IAuthorizationRequirement
    {
        public readonly ValidationMode Mode;

        public UserTokenRequirement(ValidationMode mode) 
        {
            this.Mode = mode;
        }
    }
}
