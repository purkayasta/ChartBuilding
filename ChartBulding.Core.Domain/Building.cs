using System;

namespace ChartBulding.Core.Domain
{
    public class Building : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
