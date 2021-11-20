using ChartBulding.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChartBuilding.Infrastructure.Repository.Driver
{
    internal class SqlServerDbContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Reading> Readings { get; set; }
    }
}
