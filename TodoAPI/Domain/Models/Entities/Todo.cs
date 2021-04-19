using System.ComponentModel.DataAnnotations;
using Mapster;

namespace TodoAPI.Domain.Models.Entities
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

        [AdaptIgnore]
        public long UserId { get; set; }
        [AdaptIgnore]
        public User User { get; set; }
    }
}
