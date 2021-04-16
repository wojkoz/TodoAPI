namespace TodoAPI.Domain.Models.Entities
{
    public partial class TodoDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}