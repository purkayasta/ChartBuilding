using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoBogus;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;

namespace Chartbuilding.Generator
{
    internal class DummyReadings : IRunner
    {
        private readonly IReadingRepository readingRepository;
        private readonly IBuildingRepository buildingRepository;
        private readonly IDataFieldRepository fieldRepository;
        private readonly IObjectRepository objectRepository;

        public DummyReadings(IReadingRepository readingRepository, IBuildingRepository buildingRepository, IDataFieldRepository fieldRepository, IObjectRepository objectRepository)
        {
            this.readingRepository = readingRepository;
            this.buildingRepository = buildingRepository;
            this.fieldRepository = fieldRepository;
            this.objectRepository = objectRepository;
        }

        public async ValueTask Generate()
        {
            var buildingList = await buildingRepository.GetAllAsync();
            var objectList = await objectRepository.GetAllAsync();
            var dataFieldList = await fieldRepository.GetAllAsync();
            var readingList = new List<Reading>();
            var autoFaker = AutoFaker.Create();
            var dateTimer = DateTime.Now;

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                readingList.Add(new Reading
                {
                    BuildingId = random.Next(0, buildingList.Count()),
                    DataFieldId = random.Next(0, dataFieldList.Count()),
                    ObjectId = random.Next(0, objectList.Count()),
                    Value = autoFaker.Generate<int>(),
                    TimeStamp = dateTimer.AddMinutes(1),
                    CreatedOn = dateTimer
                });
            }

            await readingRepository.AddManyAsync(readingList);
            await readingRepository.SaveAsync();
            Console.WriteLine("--- Finished ---");
        }
    }
}
