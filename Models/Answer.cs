using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; } = Guid.NewGuid();

        public Guid QuestionId { get; set; }

        public string? Content { get; set; }

        public bool IsCorrect { get; set; }
    }
}
