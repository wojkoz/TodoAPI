using System.Collections.Generic;
using TodoAPI.Domain.Models.Entities;

namespace TodoAPI.Domain.Models.Entities
{
    public partial class UserDto
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public List<TodoDto> Todos { get; set; }
    }
}