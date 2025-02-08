using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VersioningApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet("greeting")]
        [MapToApiVersion("1.0")]    
        public string GetGreting()
        {
            return "Hello world";
        }

        [HttpGet("today")]
        [MapToApiVersion("1.0")]
        public string GetToday()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet("tommorow")]
        [MapToApiVersion("2.0")]
        public string GetTomorrow()
        {
            return DateTime.Now.AddDays(1).ToString();
        }

    }
}
