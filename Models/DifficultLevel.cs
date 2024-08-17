using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Backend.Models
{
    public class DifficultLevel
    {
        [Key]
        public Guid DifficultLevelId { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
