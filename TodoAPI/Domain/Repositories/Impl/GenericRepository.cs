using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.DBContext;

namespace TodoAPI.Domain.Repositories.Impl
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> Db;

        public GenericRepository(ApplicationDbContext context)
        {
            Context = context;
            Db = Context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, IEnumerable<string> includes = null)
        {
            IQueryable<T> query = Db;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperty) =>
                    current.Include(includeProperty));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, IEnumerable<string> includes = null)
        {
            IQueryable<T> query = Db;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, includeProperty) => 
                    current.Include(includeProperty));
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T entity)
        {
            await Db.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await Db.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await Db.FindAsync(id);
            Db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Db.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
