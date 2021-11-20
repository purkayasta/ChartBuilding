using ChartBuilding.Core.Interface;
using ChartBuilding.Infrastructure.Repository.Driver;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Infrastructure.Repository
{
    internal class ObjectRepsitory : RepositoryBase<Object>, IObjectRepository
    {
        public ObjectRepsitory(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
