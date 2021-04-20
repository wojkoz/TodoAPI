using TodoAPI.Domain.DBContext;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Repository.Impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
