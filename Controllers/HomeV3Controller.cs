using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VersioningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ControllerName("Home")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("3.0")]
    public class HomeV3Controller : Controller
    {

        [HttpGet("Welcome/{name}")]
        [MapToApiVersion("3.0")]
        [Obsolete("this method is deprecated use another method", true)]
        public IActionResult welcome(string name)
        {
            return Ok($"WElocme {name}");
        }
    }
}
