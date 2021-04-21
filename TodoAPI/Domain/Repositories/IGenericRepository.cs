
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoAPI.Domain.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IEnumerable<string> includes = null);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null);

        Task InsertAsync(T entity);

        Task InsertRangeAsync(IEnumerable<T> entities);

        Task DeleteAsync(long id);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);

        Task Save();
    }
}
