
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Models.Entities
{
    public record Password
    {
        [Key]
        public long Id { get; init; }
        [Required]
        [MaxLength(100)]
        public string UserPassword { get; init; }
    }
}
