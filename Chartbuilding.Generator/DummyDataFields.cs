
using System.Threading.Tasks;
using AutoBogus;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace Chartbuilding.Generator
{
    internal class DummyDataFields : IRunner
    {
        private readonly IDataFieldRepository dataFieldRepository;

        public DummyDataFields(IDataFieldRepository dataFieldRepository)
        {
            this.dataFieldRepository = dataFieldRepository;
        }

        public async ValueTask Generate()
        {
            System.Console.WriteLine("===========Started DataFields========");
            var autoFaker = AutoFaker.Create();
            var buildings = autoFaker.Generate<DataField>(200);
            await dataFieldRepository.AddManyAsync(buildings);
            await dataFieldRepository.SaveAsync();
            System.Console.WriteLine("===========Finished========");
        }
    }
}
