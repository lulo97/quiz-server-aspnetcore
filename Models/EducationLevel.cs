using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class EducationLevel
    {
        [Key]
        public Guid EducationLevelId { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<SubSubject> SubSubjects { get; set; } = new List<SubSubject>();
    }
}
