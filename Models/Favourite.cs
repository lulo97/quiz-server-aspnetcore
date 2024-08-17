using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Favourite
    {
        [Key]
        public Guid FavouriteId { get; set; } = Guid.NewGuid();

        public Guid QuizId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
