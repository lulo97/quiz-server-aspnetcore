using Backend.Models;

namespace Backend.DTOs
{
    public class EducationLevelDTO
    {
        public Guid EducationLevelId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<SubSubject> SubSubjects { get; set; } = new List<SubSubject>();
    }
}
