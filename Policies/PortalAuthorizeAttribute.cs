using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace lab_authorize.Policies
{
    public class PortalAuthorizeAttribute :AuthorizeAttribute
    {
        private readonly string _action;
        private readonly ValidationMode _forAccountToken;
        private readonly ValidationMode _forUserToken;
        
        public PortalAuthorizeAttribute(string action, ValidationMode forAccountToken, ValidationMode forUserToken)
        {
            this._action = action;
            this._forAccountToken = forAccountToken;
            this._forUserToken = forUserToken;

            this.Policy = $"{PortalAuthorizeConst.POLICY_PREFIX}_A={forAccountToken}_U={forUserToken}_P={action}";
        }

        public PortalAuthorizeAttribute(ValidationMode forAccountToken, ValidationMode forUserToken)
            : this(action: string.Empty, forAccountToken: forAccountToken, forUserToken: forUserToken)
        {

        }

        public PortalAuthorizeAttribute() 
            :this(action: string.Empty, forAccountToken: ValidationMode.Basic, forUserToken: ValidationMode.Basic)
        {

        }

        public PortalAuthorizeAttribute(string action)
            : this(action: action, forAccountToken: ValidationMode.Basic, forUserToken: ValidationMode.Basic)
        {

        }
    }

    public static class PortalAuthorizeConst 
    {
        public static readonly string POLICY_PREFIX = "_PORTAL";
        public static readonly string AccountTokenKey = "X-ACCOUNT-TOKEN";
        public static readonly string UserTokenKey = "X-USER-TOKEN";
    }
}
