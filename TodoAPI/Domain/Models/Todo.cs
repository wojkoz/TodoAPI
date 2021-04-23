using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public string UserId { get; set; }
    }
}
