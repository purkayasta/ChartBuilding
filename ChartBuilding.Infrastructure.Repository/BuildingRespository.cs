using ChartBuilding.Core.Repository.Driver;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace ChartBuilding.Core.Repository
{
    public class BuildingRespository : RepositoryBase<Building>, IBuildingRepository
    {
        public BuildingRespository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
