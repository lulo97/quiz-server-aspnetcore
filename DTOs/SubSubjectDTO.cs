namespace Backend.DTOs
{
    public class SubSubjectDTO
    {
        public Guid SubSubjectId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid EducationLevelId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? SubjectName { get; set; } = "";
        public string? EducationLevelName { get; set; }
    }
}
