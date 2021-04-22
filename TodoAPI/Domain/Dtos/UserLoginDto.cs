
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}
