
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoAPI.Domain.DBContext;

namespace TodoAPI.Domain.Repository.Impl
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
