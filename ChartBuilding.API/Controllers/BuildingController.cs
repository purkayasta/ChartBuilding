using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChartBuilding.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await _buildingService.GetAllAsync();
            return Ok(result);
        }
    }
}
