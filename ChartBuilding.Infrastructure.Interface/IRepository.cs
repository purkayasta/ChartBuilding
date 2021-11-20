using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChartBuilding.Core.Interface
{
    public interface IRepository<T> where T : class
    {
        ValueTask<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> queries);
        ValueTask<T> FindOneAsync(Expression<Func<T, bool>> queries);
        Task<int> CountAsync(Expression<Func<T, bool>> queries);
    }
}
