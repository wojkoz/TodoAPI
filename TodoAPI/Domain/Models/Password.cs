
using System.ComponentModel.DataAnnotations;
using Mapster;

namespace TodoAPI.Domain.Models
{
    public record Password
    {
        public long PasswordId { get; init; }
        [Required]
        [MaxLength(100)]
        public string UserPassword { get; init; }

        [AdaptIgnore]
        public long UserId { get; set; }
        [AdaptIgnore]
        public User User { get; set; }
    }
}
