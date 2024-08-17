using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Follow
    {
        [Key]
        public Guid FollowId { get; set; } = Guid.NewGuid();

        public Guid FollowerId { get; set; }

        public Guid FolloweeId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
