using System.Threading.Tasks;
using AutoBogus;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace Chartbuilding.Generator
{
    internal class DummyBuildings : IRunner
    {
        private readonly IBuildingRepository buildingRepository;

        public DummyBuildings(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }

        public async ValueTask Generate()
        {
            System.Console.WriteLine("===========Started Buildings========");
            var autoFaker = AutoFaker.Create();
            var buildings = autoFaker.Generate<Building>(100);
            await buildingRepository.AddManyAsync(buildings);
            await buildingRepository.SaveAsync();
            System.Console.WriteLine("===========Finished========");
        }
    }
}
