using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Point
    {
        [Key]
        public Guid PointId { get; set; } = Guid.NewGuid();

        public int Value { get; set; }

        public bool IsPenalty { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
