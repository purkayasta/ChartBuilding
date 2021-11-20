using System.Collections.Generic;
using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Interfaces
{
    public interface IBuildingService
    {
        ValueTask<IEnumerable<BuildingDto>> GetAllAsync();
    }
}
