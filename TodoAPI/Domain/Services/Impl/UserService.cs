using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Extensions;
using TodoAPI.Domain.Models;
using TodoAPI.Domain.Repositories;

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
            await _userRepository.CreateUser(createUserDto.Password, createUserDto.ToUser());
            var user = await _userRepository.GetAsync(u => u.Email == createUserDto.Email);
            Console.WriteLine(user.ToString());
            return user.AdaptToDto();
        }

        public async Task<UserDto> GetUserAsync(long id)
        {
            var user = await _userRepository.GetAsync(u => u.UserId == id);

            return user?.AdaptToDto();
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);

            return user?.AdaptToDto();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users?.Adapt<IEnumerable<UserDto>>();
        }

        public async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var isAuthenticated = await _userRepository.AuthenticateAsync(email, password);

            return isAuthenticated;
        }
    }
}
