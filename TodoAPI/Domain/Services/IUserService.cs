using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserAsync(long id);
        Task<UserDto> GetUserAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<bool> AuthenticateUserAsync(string email, string password);
    }
}
