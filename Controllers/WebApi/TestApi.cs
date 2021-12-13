using lab_authorize.Filters;
using Microsoft.AspNetCore.Mvc;

namespace lab_authorize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        // [ClaimRequirement(MyClaimTypes.Permission, "CanReadResource")]
        public ActionResult<string> permission()
        {
            return "hi there~";
        }
    }
}

