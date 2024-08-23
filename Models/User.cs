using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    //Email, UserName, Primary Key already implement in IdentityUser
    public class User: IdentityUser<Guid>
    {
        [Required]
        public string? Fullname { get; set; }

        public string? Biography { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
