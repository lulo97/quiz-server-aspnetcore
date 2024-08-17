using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Rating
    {
        [Key]
        public Guid RatingId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid QuizId { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
