using System;

namespace ChartBuilding.Infrastructure.Service.Mapper.Models
{
    public class ReadingDto
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
