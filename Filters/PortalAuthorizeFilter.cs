using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lab_authorize.Filters
{
    //public class PortalAuthorizeFilter : IAuthorizationFilter
    //{
    //    private readonly string _action;
    //    private readonly ValidationMode _forAccountToken;
    //    private readonly ValidationMode _forUserToken;
    //    public static readonly string AccountTokenKey = "X-ACCOUNT-TOKEN";
    //    public static readonly string UserTokenKey = "X-USER-TOKEN";
    //    public PortalAuthorizeFilter(string action, ValidationMode forAccountToken = ValidationMode.Basic, ValidationMode forUserToken = ValidationMode.Basic)
    //    {
    //        this._action = action ?? string.Empty;
    //        _forAccountToken = forAccountToken;
    //        _forUserToken = forUserToken;
    //    }

    //    public PortalAuthorizeFilter(ValidationMode forAccountToken = ValidationMode.Basic, ValidationMode forUserToken = ValidationMode.Basic)
    //        : this(string.Empty, forAccountToken, forUserToken) { }

    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        var accountToken = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == AccountTokenKey)?.Value;
    //        var userToken = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == UserTokenKey)?.Value;

    //        if (context.Filters.Any(item => item is IAllowAnonymousFilter)) return;

    //        if (string.IsNullOrEmpty(accountToken)|| string.IsNullOrEmpty(userToken))
    //            context.Result = new ForbidResult();


    //        if (string.IsNullOrWhiteSpace(_action) == false)
    //        {
    //            if (userToken != "admin") 
    //            {
    //                context.Result = new ForbidResult();
    //            }
    //        }
    //    }
    //}

    //public class PortalAuthorizeAttribute : TypeFilterAttribute
    //{
    //    public PortalAuthorizeAttribute(string action, ValidationMode forAccountToken, ValidationMode forUserToken) 
    //        : base(typeof(PortalAuthorizeFilter))
    //    {
    //        Arguments = new object[] { action, forAccountToken, forUserToken };
    //    }

    //    public PortalAuthorizeAttribute(ValidationMode forAccountToken, ValidationMode forUserToken)
    //        : this(string.Empty, forAccountToken, forUserToken)
    //    {

    //    }

    //    public PortalAuthorizeAttribute()
    //        : this(string.Empty, ValidationMode.Basic, ValidationMode.Basic)
    //    {

    //    }

    //    public PortalAuthorizeAttribute(string action)
    //       : this(action, ValidationMode.Basic, ValidationMode.Basic)
    //    {

    //    }
    //}
}