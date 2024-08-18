using Backend.Models;

namespace Backend.DTOs
{
    public class SubjectDTO
    {
        public Guid SubjectId { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public List<SubSubject> SubSubjects { get; set; } = new List<SubSubject>();
    }
}
