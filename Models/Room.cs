using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; } = Guid.NewGuid();

        public Guid QuizId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public DateTime StartQuizTime { get; set; }

        public int Capacity { get; set; } = 10;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? Password { get; set; }

    }
}
