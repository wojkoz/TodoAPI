using TodoAPI.Domain.Models;

namespace TodoAPI.Domain.Models
{
    public static partial class TodoMapper
    {
        public static TodoDto AdaptToDto(this Todo p1)
        {
            return p1 == null ? null : new TodoDto()
            {
                TodoId = p1.TodoId,
                Title = p1.Title,
                Description = p1.Description,
                UserId = p1.UserId
            };
        }
        public static TodoDto AdaptTo(this Todo p2, TodoDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            TodoDto result = p3 ?? new TodoDto();
            
            result.TodoId = p2.TodoId;
            result.Title = p2.Title;
            result.Description = p2.Description;
            result.UserId = p2.UserId;
            return result;
            
        }
    }
}