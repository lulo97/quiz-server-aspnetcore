using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Quiz
    {
        [Key]
        public Guid QuizId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid EducationLevelId { get; set; }

        public Guid SubjectId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        public bool IsPublic { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public Guid UserVerifiedId { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
