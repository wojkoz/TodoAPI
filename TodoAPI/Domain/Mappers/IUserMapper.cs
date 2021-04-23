using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Mappers
{
    [Mapper]
    public interface IUserMapper
    {
        UserDto AdaptToDto(User user);
    }
}
