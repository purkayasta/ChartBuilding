using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Interfaces
{
    public interface IReadingService
    {
        ValueTask<IEnumerable<ReadingDto>> GetChartAsync(DateTime startDate, DateTime endDate);
        ValueTask<IEnumerable<ReadingDto>> GetChartAsync(int? buildinId, int? objectId, int? dataFieldId, DateTime startDate, DateTime endDate);
    }
}
