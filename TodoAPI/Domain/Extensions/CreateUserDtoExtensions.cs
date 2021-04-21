﻿using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Extensions
{
    public static class CreateUserDtoExtensions
    {
        public static User ToUser(this CreateUserDto dto)
        {
            return new ()
            {
                Todos = null,
                Email = dto.Email,
                Nickname = dto.Nickname,
            };
        }
    }
}
