using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class UserRoom
    {
        [Key]
        public Guid UserRoomId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public DateTime JoinRoomTime { get; set; }

        public DateTime LeaveRoomTime { get; set; }

        public DateTime StartQuizTime { get; set; }

        public DateTime SubmitQuizTime { get; set; }
    }
}
