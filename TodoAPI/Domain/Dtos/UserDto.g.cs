using System.Collections.Generic;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Models
{
    public partial class UserDto
    {
        public long UserId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public List<TodoDto> Todos { get; set; }
    }
}