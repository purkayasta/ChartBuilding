using ChartBuilding.Core.Repository.Driver;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Core.Repository
{
    internal class ObjectRepsitory : RepositoryBase<Object>, IObjectRepository
    {
        public ObjectRepsitory(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
