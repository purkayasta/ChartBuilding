using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChartBuilding.Infrastructure.Interface
{
    public interface IRepository<T> where T : class
    {
        ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> queries);
        ValueTask<T> FindOneAsync(Expression<Func<T, bool>> queries);
        Task<int> CountAsync(Expression<Func<T, bool>> queries);
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask Add(T entity);
        ValueTask AddManyAsync(IEnumerable<T> entities);
        ValueTask SaveAsync();
        IQueryable<T> FindWithOrderBy(Expression<Func<T, bool>> queries, Expression<Func<T, object>> orderBy);
        IQueryable<T> FindWithOrderByDesending(Expression<Func<T, bool>> queries, Expression<Func<T, object>> orderBy);
    }
}
