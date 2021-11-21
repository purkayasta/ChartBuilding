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

            var dateTimer = new DateTime(2021, 11, 10);

            Random random = new Random();

            int target = 60000;
            for (int i = 0; i < target; i++)
            {
                if (i % 5 == 0)
                    dateTimer = dateTimer.AddMinutes(5);

                readingList.Add(new Reading
                {
                    BuildingId = random.Next(0, buildingList.Count()),
                    DataFieldId = random.Next(0, dataFieldList.Count()),
                    ObjectId = random.Next(0, objectList.Count()),
                    Value = i,
                    TimeStamp = dateTimer,
                    CreatedOn = DateTime.Now,
                });
            }

            await readingRepository.AddManyAsync(readingList);
            await readingRepository.SaveAsync();
            Console.WriteLine("--- Finished ---");
        }
    }
}
