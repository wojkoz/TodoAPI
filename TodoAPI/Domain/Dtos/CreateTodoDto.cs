
namespace TodoAPI.Domain.Dtos
{
    public record CreateTodoDto
    {
        public long UserId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
