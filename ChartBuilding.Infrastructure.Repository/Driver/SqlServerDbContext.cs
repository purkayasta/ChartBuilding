using ChartBulding.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChartBuilding.Core.Repository.Driver
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Reading> Readings { get; set; }
    }
}
