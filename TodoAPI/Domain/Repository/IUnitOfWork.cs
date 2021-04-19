using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Todo> Todos { get; }
        IGenericRepository<Password> Passwords { get; }

        Task Save();

    }
}
