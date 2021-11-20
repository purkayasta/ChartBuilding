namespace ChartBulding.Core.Domain
{
    public class Object : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
