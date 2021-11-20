using AutoMapper;
using ChartBuilding.Infrastructure.Service.Mapper.Models;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Infrastructure.Service.Mapper
{
    public class Profiler : Profile
    {
        public Profiler()
        {
            CreateMap<ReadingDto, Reading>().ReverseMap();
            CreateMap<BuildingDto, Building>().ReverseMap();
            CreateMap<DataFieldDto, DataField>().ReverseMap();
            CreateMap<ObjectDto, Object>().ReverseMap();
        }
    }
}
