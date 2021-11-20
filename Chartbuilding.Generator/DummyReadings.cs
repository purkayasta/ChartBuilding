using System;
using System.Threading.Tasks;
using ChartBuilding.Infrastructure.Interface;

namespace Chartbuilding.Generator
{
    internal class DummyReadings : IRunner
    {
        private readonly IReadingRepository readingRepository;

        public DummyReadings(IReadingRepository readingRepository)
        {
            this.readingRepository = readingRepository;
        }

        public async ValueTask Generate()
        {
            throw new NotImplementedException();
        }
    }
}
