using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid TypeId { get; set; }

        //Can extract Subject and Education from SubSubject
        public Guid SubSubjectId { get; set; }

        public Guid DifficultLevelId { get; set; }

        public Guid LanguageId { get; set; }

        public Guid TimeId { get; set; }

        public Guid PointId { get; set; }

        public Guid PenaltyPointId { get; set; }

        public Guid BookId { get; set; }

        //Metadata
        [Required]
        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public string? AudioUrl { get; set; }

        public string? Explanation { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
