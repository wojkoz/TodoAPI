using TodoAPI.Domain.DBContext;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Repositories.Impl
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
