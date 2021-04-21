using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Domain.DBContext;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Repositories.Impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await Db.FirstOrDefaultAsync(u => u.Email == email);

            if (user is null)
            {
                return false;
            }

            var userPass = await Context.Passwords.FirstOrDefaultAsync(p => p.UserId == user.UserId);
            return userPass is not null && userPass.UserPassword == password;
        }

        public async Task CreateUser(string password, User user)
        {
            await Db.AddAsync(user);
            await Save();
            var entity = await Db.FirstOrDefaultAsync(u => u.Email == user.Email);

            var pass = new Password()
            {
                User = entity,
                UserId = entity.UserId,
                UserPassword = password
            };

            await Context.Passwords.AddAsync(pass);
            await Save();
        }
    }
}
