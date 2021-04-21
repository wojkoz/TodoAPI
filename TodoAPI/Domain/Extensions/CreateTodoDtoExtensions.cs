using TodoAPI.Domain.Dtos;
using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Extensions
{
    public static class CreateTodoDtoExtensions
    {
        public static Todo ToTodo(this CreateTodoDto dto)
        {
            return new()
            {
                UserId = dto.UserId,
                Description = dto.Description,
                Title = dto.Title
            };
        }
    }
}
