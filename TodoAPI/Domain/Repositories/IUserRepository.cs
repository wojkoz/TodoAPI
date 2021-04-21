using System.Threading.Tasks;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task CreateUser(string password, User user);
    }
}
