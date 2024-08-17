using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Play
    {
        [Key]
        public Guid PlayId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid QuizId { get; set; }

        public Guid RoomId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime SubmitTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
