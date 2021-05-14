
namespace TodoAPI.Domain.Dtos
{
    public record CreateTodoDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
    }
}
