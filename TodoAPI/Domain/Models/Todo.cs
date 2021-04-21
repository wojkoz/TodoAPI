using System.ComponentModel.DataAnnotations;
using Mapster;

namespace TodoAPI.Domain.Models
{
    [AdaptTo("[name]Dto"), GenerateMapper]
    public record Todo
    {
        public long TodoId { get; init; }
        [MaxLength(50)]
        [Required]
        public string Title { get; init; }
        [MaxLength(250)]
        public string Description { get; init; }

        public long UserId { get; set; }
        [AdaptIgnore]
        public User User { get; set; }
    }
}
