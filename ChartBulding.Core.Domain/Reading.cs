using System;

namespace ChartBulding.Core.Domain
{
    public class Reading : BaseEntity, IEntity
    {
        public int BuildingId { get; set; }
        public int ObjectId { get; set; }
        public int DataFieldId { get; set; }
        public int Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
