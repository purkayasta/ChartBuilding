using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChartBuilding.Infrastructure.Interface;
using ChartBuilding.Infrastructure.Service.Interfaces;
using ChartBuilding.Infrastructure.Service.Mapper.Models;

namespace ChartBuilding.Infrastructure.Service.Implementations
{
    public class DataFieldService : IDataFieldService
    {
        private readonly IDataFieldRepository _repository;
        private readonly IMapper _mapper;

        public DataFieldService(IDataFieldRepository repository)
        {
            _repository = repository;
        }
        public async ValueTask<IEnumerable<DataFieldDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DataFieldDto>>(result);
        }
    }
}
