namespace ChartBulding.Core.Domain
{
    public class DataField : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
