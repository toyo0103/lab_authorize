using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies.Requirements
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public readonly string Action;

        public PermissionRequirement(string action) 
        {
            this.Action = action;
        }
    }
}
