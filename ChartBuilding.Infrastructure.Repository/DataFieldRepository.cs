using ChartBuilding.Core.Interface;
using ChartBuilding.Infrastructure.Repository.Driver;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Infrastructure.Repository
{
    internal class DataFieldRepository : RepositoryBase<DataField>, IDataFieldRepository
    {
        public DataFieldRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
