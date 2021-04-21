using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mapster;

namespace TodoAPI.Domain.Models
{
    [AdaptTo("[name]Dto"), GenerateMapper]
    public record User
    {
        public long UserId { get; init; }
        [MaxLength(50)]
        [Required]
        public string Nickname { get; init; }
        [MaxLength(50)]
        [Required]
        public string Email { get; init; }
        [Required]
        [AdaptIgnore]
        public Password Password { get; init; }
        [Required]
        public virtual List<Todo> Todos { get; init; }
    }
}
