using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoBogus;
using ChartBuilding.Configurations;
using ChartBuilding.Infrastructure.Interface;
using ChartBulding.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Chartbuilding.Generator
{
    internal class Program
    {
        private static IBuildingRepository buildingRepository;
        private static IReadingRepository readingRepository;
        private static IDataFieldRepository fieldRepository;
        private static IObjectRepository objectRepository;

        static async Task Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            timer.Start();

            AutoFaker.Configure(builder =>
            {
                builder.WithSkip<Building>(x => x.Id);
                builder.WithSkip<ChartBulding.Core.Domain.Object>(x => x.Id);
                builder.WithSkip<DataField>(x => x.Id);
                builder.WithSkip<Reading>(x=> x.Id);
            });

            IntializeDiContainer();
            await new DummyBuildings(buildingRepository).Generate();
            await new DummyDataFields(fieldRepository).Generate();
            await new DummyObjects(objectRepository).Generate();
            await new DummyReadings(readingRepository, buildingRepository, fieldRepository, objectRepository).Generate();
            Console.WriteLine($"Finished Task => {timer.Elapsed.TotalSeconds} seconds");
            timer.Stop();
        }

        static void IntializeDiContainer()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSqlServer("data source=DESKTOP-EIGTBNO\\SQLEXPRESS; initial catalog=S3; Integrated Security=True;");
            serviceCollection.AddRepositoryDependency();
            var serviceProvider = serviceCollection.BuildServiceProvider();


            buildingRepository = serviceProvider.GetRequiredService<IBuildingRepository>();
            readingRepository = serviceProvider.GetRequiredService<IReadingRepository>();
            fieldRepository = serviceProvider.GetRequiredService<IDataFieldRepository>();
            objectRepository = serviceProvider.GetRequiredService<IObjectRepository>();
        }
    }
}
