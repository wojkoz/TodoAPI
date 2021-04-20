using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models.Entities;
using TodoAPI.Domain.Repository;

namespace TodoAPI.Domain.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
