using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
