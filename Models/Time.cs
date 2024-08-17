using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    //Time is total second of question
    //Time of a quiz is total time of all question inside it
    //We have 2 mode for play:
    //  Play question by question and can't return and show time per question
    //  Can go back to previous question and show quiz time, time per question does not matter
    public class Time
    {
        [Key]
        public Guid TimeId { get; set; } = Guid.NewGuid();

        [Required]
        public int SecondValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
