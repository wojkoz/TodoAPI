using System.Collections.Generic;
using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Mappers;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Mappers
{
    public partial class UserMapper : IUserMapper
    {
        public UserDto AdaptToDto(User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Todos = funcMain1(p1.Todos),
                Id = p1.Id,
                UserName = p1.UserName,
                Email = p1.Email
            };
        }
        
        private List<TodoDto> funcMain1(List<Todo> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<TodoDto> result = new List<TodoDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                Todo item = p2[i];
                result.Add(item == null ? null : new TodoDto()
                {
                    TodoId = item.TodoId,
                    Title = item.Title,
                    Description = item.Description,
                    UserId = item.UserId
                });
                i++;
            }
            return result;
            
        }
    }
}