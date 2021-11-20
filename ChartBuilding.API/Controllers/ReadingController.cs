using System;
using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChartBuilding.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingService _readingService;

        public ReadingController(IReadingService readingService)
        {
            _readingService = readingService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get(int? buildingId, int? objectId, int? dataFieldId, DateTime startDate, DateTime endDate)
        {
            var result = await _readingService.GetChartAsync(buildingId, objectId, dataFieldId, startDate, endDate);
            return Ok(result);
        }
    }
}
