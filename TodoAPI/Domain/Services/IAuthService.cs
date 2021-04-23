using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TodoAPI.Domain.Dtos;

namespace TodoAPI.Domain.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(UserRegisterDto dto);
        Task<LoginResponse> LoginAsync(UserLoginDto dto);
    }
}
