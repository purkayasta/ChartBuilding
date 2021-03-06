using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChartBuilding.Infrastructure.Interface;
using ChartBuilding.Infrastructure.Service.Interfaces;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Implementations
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _repository = buildingRepository;
            _mapper = mapper;
        }

        public async ValueTask<IEnumerable<BuildingDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BuildingDto>>(result); ;
        }
    }
}
