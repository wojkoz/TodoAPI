using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Extensions
{
    public static class TodoDtoExtensions
    {
        public static Todo ToTodo(this TodoDto dto)
        {
            return new()
            {
                Description = dto.Description,
                Title = dto.Title,
                TodoId = dto.TodoId,
                UserId = dto.UserId
            };
        }
    }
}
