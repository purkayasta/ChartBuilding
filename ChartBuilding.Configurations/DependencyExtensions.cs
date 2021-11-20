using System;
using ChartBuilding.Core.Repository;
using ChartBuilding.Infrastructure.Interface;
using ChartBuilding.Infrastructure.Service.Implementations;
using ChartBuilding.Infrastructure.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChartBuilding.Configurations
{
    public static class DependencyExtensions
    {
        public static void AddAutomapper(this IServiceCollection services, Type appType)
        {
            services.AddAutoMapper(appType);
        }

        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IDataFieldService, DataFieldService>();
            services.AddScoped<IObjectService, ObjectService>();
            services.AddScoped<IReadingService, ReadingService>();
        }

        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IBuildingRepository, BuildingRespository>();
            services.AddScoped<IDataFieldRepository, DataFieldRepository>();
            services.AddScoped<IObjectRepository, ObjectRepsitory>();
            services.AddScoped<IReadingRepository, ReadingRepository>();
        }
    }
}
