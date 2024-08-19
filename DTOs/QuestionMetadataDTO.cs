using Backend.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Backend.DTOs
{
    public class QuestionMetadataDTO
    {
        public List<DifficultLevel> DifficultLevels { get; set; } = new List<DifficultLevel>();
        public List<EducationLevel> EducationLevels { get; set; } = new List<EducationLevel>();
        public List<Language> Languages { get; set; } = new List<Language>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<SubSubject> SubSubjects { get; set; } = new List<SubSubject>();
        public List<QuestionType> QuestionTypes { get; set; } = new List<QuestionType>();
        public List<Point> Points { get; set; } = new List<Point>();
        public List<Point> PenaltyPoints { get; set; } = new List<Point>();
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
