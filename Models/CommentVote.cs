using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CommentVote
    {
        [Key]
        public Guid CommentVoteId { get; set; } = Guid.NewGuid();

        public Guid CommentId { get; set; }

        public Guid UserId { get; set; }

        public bool IsUpvote { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
