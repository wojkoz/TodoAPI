using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Domain.Dtos
{
    public class UserRegisterDto : UserLoginDto
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
