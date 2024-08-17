using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ApplicationConst
    {
        [Key]
        public Guid ApplicationConstId { get; set; } = Guid.NewGuid();

        [Required]
        public string? Key { get; set; }

        [Required]
        public string? Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
