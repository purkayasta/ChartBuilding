using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartBuilding.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello World");
    }
}
