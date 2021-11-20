using ChartBuilding.Core.Repository.Driver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChartBuilding.Configurations
{
    public static class DatabaseExtensions
    {
        public static void AddSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SqlServerDbContext>(server => server.UseLazyLoadingProxies().UseSqlServer(connectionString));
        }
    }
}
