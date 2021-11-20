using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChartBuilding.Core.Repository.Driver;
using ChartBuilding.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace ChartBuilding.Core.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly DbContext _dbContext;

        public RepositoryBase(SqlServerDbContext dbContext)
        {
            _table = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync() => await _table.ToListAsync();

        public async Task<int> CountAsync(Expression<Func<T, bool>> queries) => await _table.CountAsync(queries);

        public async ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> queries) => await _table.Where(queries).AsNoTracking().ToListAsync();

        public async ValueTask<T> FindOneAsync(Expression<Func<T, bool>> queries) => await _table.Where(queries).FirstOrDefaultAsync();

        public async ValueTask Add(T entity) => await _table.AddAsync(entity);
        public async ValueTask AddManyAsync(IEnumerable<T> entities) => await _table.AddRangeAsync(entities);
        public async ValueTask SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
