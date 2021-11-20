using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChartBuilding.Infrastructure.Interface;
using ChartBuilding.Infrastructure.Service.Interfaces;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Implementations
{
    public class ReadingService : IReadingService
    {
        private readonly IReadingRepository _repository;
        private readonly IMapper _mapper;

        public ReadingService(IReadingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async ValueTask<IEnumerable<ReadingDto>> GetChartAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _repository.FindAsync(x => x.TimeStamp >= startDate && x.TimeStamp < endDate);
            return _mapper.Map<IEnumerable<ReadingDto>>(result);
        }

        public async ValueTask<IEnumerable<ReadingDto>> GetChartAsync(int? buildinId, int? objectId, int? dataFieldId, DateTime startDate, DateTime endDate)
        {
            var result = await _repository.FindAsync(x => x.TimeStamp >= startDate && x.TimeStamp < endDate
                                        && (buildinId == null || x.BuildingId == buildinId)
                                        && (objectId == null || x.ObjectId == objectId)
                                        && (dataFieldId == null || x.DataFieldId == dataFieldId));

            return _mapper.Map<IEnumerable<ReadingDto>>(result);
        }
    }
}
