using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChartBuilding.Infrastructure.Interface;
using ChartBuilding.Infrastructure.Service.Interfaces;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Implementations
{
    public class ObjectService : IObjectService
    {
        private readonly IObjectRepository _repository;
        private readonly IMapper _mapper;

        public ObjectService(IObjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async ValueTask<IEnumerable<ObjectDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ObjectDto>>(result);
        }
    }
}
