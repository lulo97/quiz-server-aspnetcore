using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class SubSubject
    {
        [Key]
        public Guid SubSubjectId { get; set; } = Guid.NewGuid();

        public Guid SubjectId { get; set; }

        public Guid EducationLevelId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public Subject? Subject { get; set; }
        public EducationLevel? EducationLevel { get; set; }
    }
}
