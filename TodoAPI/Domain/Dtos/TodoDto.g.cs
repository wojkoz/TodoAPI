namespace TodoAPI.Domain.Models.Entities
{
    public partial class TodoDto
    {
        public long TodoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
    }
}