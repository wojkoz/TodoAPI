using System;
using System.Collections.Generic;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Dtos
{
    public class UserDto
    {
        public List<TodoDto> Todos { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        
    }
}