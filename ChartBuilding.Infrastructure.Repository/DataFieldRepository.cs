using ChartBuilding.Core.Repository.Driver;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Core.Repository
{
    public class DataFieldRepository : RepositoryBase<DataField>, IDataFieldRepository
    {
        public DataFieldRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
