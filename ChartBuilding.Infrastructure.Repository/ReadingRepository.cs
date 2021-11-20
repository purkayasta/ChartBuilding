using ChartBuilding.Core.Repository.Driver;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Core.Repository
{
    public class ReadingRepository : RepositoryBase<Reading>, IReadingRepository
    {
        public ReadingRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
