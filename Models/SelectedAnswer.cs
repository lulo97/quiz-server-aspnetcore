using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class SelectedAnswer
    {
        [Key]
        public Guid SelectedAnswerId { get; set; } = Guid.NewGuid();

        public Guid PlayId { get; set; }

        public Guid AnswerId { get; set; }
    }
}
