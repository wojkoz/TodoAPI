
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Dtos
{
    public record CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string Nickname { get; init; }
        [Required]
        [MaxLength(50)]
        public string Email { get; init; }
        [Required]
        [MaxLength(50)]
        public string Password { get; init; }
        
    }
}
