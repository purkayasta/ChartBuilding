using ChartBuilding.Core.Interface;
using ChartBuilding.Infrastructure.Repository.Driver;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Infrastructure.Repository
{
    internal class ReadingRepository : RepositoryBase<Reading>, IReadingRepository
    {
        public ReadingRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
