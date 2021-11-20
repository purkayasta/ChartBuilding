using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChartBuilding.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataFieldController : ControllerBase
    {
        private readonly IDataFieldService _dataFieldService;

        public DataFieldController(IDataFieldService dataFieldService)
        {
            _dataFieldService = dataFieldService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await _dataFieldService.GetAllAsync();
            return Ok(result);
        }
    }
}
