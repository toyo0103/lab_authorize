using lab_authorize.Filters;
using lab_authorize.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab_authorize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("permission")]
        [PortalAuthorize(action: "bbs:list.posts")]
        public ActionResult<string> permission()
        {
            return "hi permission~";
        }

        [HttpGet]
        [Route("basic")]
        public ActionResult<string> basic()
        {
            return "hi basic~";
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("anonymous")]
        public ActionResult<string> anonymous()
        {
            return "hi anonymouse~";
        }
    }
}

