using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Domain.DBContext;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Repository.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<User> _users;
        private IGenericRepository<Todo> _todos;
        private IGenericRepository<Password> _passwords;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<Todo> Todos => _todos ??= new GenericRepository<Todo>(_context);
        public IGenericRepository<Password> Passwords => _passwords ??= new GenericRepository<Password>(_context);
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
