using ChartBulding.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChartBuilding.Core.Repository.Driver
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasKey(x => x.Id);
            modelBuilder.Entity<DataField>().HasKey(x => x.Id);
            modelBuilder.Entity<Object>().HasKey(x => x.Id);
            modelBuilder.Entity<Reading>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<DataField> DataFields { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Reading> Readings { get; set; }
    }
}
