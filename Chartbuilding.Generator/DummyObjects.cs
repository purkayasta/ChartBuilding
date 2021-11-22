using System.Threading.Tasks;
using AutoBogus;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace Chartbuilding.Generator
{
    internal class DummyObjects : IRunner
    {
        private readonly IObjectRepository objectRepository;

        public DummyObjects(IObjectRepository objectRepository)
        {
            this.objectRepository = objectRepository;
        }

        public async ValueTask Generate()
        {
            System.Console.WriteLine("===========Started DataFields========");
            var autoFaker = AutoFaker.Create();
            var buildings = autoFaker.Generate<Object>(100);
            await objectRepository.AddManyAsync(buildings);
            await objectRepository.SaveAsync();
            System.Console.WriteLine("===========Finished========");
        }
    }
}
