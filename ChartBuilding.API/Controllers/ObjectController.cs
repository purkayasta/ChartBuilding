using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChartBuilding.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectService _objectService;

        public ObjectController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await _objectService.GetAllAsync();
            return Ok(result);
        }
    }
}
