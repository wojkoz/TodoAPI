using System.Collections.Generic;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Models
{
    public static partial class UserMapper
    {
        public static UserDto AdaptToDto(this User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                UserId = p1.UserId,
                Nickname = p1.Nickname,
                Email = p1.Email,
                Todos = funcMain1(p1.Todos)
            };
        }
        public static UserDto AdaptTo(this User p3, UserDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            UserDto result = p4 ?? new UserDto();
            
            result.UserId = p3.UserId;
            result.Nickname = p3.Nickname;
            result.Email = p3.Email;
            result.Todos = funcMain2(p3.Todos, result.Todos);
            return result;
            
        }
        
        private static List<TodoDto> funcMain1(List<Todo> p2)
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
        
        private static List<TodoDto> funcMain2(List<Todo> p5, List<TodoDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            List<TodoDto> result = new List<TodoDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                Todo item = p5[i];
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