using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace TodoAPI.Domain.Models
{
    public class User : IdentityUser
    {
        [Required]
        public virtual List<Todo> Todos { get; init; }
    }
}
