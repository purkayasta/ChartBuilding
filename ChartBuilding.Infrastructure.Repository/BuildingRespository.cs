using ChartBuilding.Core.Interface;
using ChartBuilding.Infrastructure.Repository.Driver;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Infrastructure.Repository
{
    internal class BuildingRespository : RepositoryBase<Building>, IBuildingRepository
    {
        public BuildingRespository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
