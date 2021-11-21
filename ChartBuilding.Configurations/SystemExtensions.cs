using ChartBuilding.Infrastructure.Service.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ChartBuilding.Configurations
{
    public static class SystemExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Profiler));
        }
    }
}
