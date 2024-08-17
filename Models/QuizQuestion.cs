using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class QuizQuestion
    {
        [Key]
        public Guid QuizQuestionId { get; set; } = Guid.NewGuid();

        public Guid QuizId { get; set; }

        public Guid QuestionId { get; set; }
    }
}
