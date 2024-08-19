using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
