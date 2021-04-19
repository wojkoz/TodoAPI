using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Domain.DBContext;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Repository.Impl
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
