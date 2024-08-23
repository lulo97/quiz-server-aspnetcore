using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend.Utils.Const;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuestionController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateQuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<QuestionMetadataDTO>> GetQuestionMetadata()
        {
            try
            {
                return new QuestionMetadataDTO
                {
                    DifficultLevels = await _context.DifficultLevels.ToListAsync(),
                    EducationLevels = await _context.EducationLevels.ToListAsync(),
                    Languages = await _context.Languages.ToListAsync(),
                    Subjects = await _context.Subjects.ToListAsync(),
                    SubSubjects = await _context.SubSubjects.ToListAsync(),
                    QuestionTypes = await _context.QuestionTypes.ToListAsync(),
                    Points = await _context.Points.Where(x => x.IsPenalty == false).ToListAsync(),
                    PenaltyPoints = await _context.Points.Where(x => x.IsPenalty == true).ToListAsync(),   
                    Books = await _context.Books.ToListAsync()
                };
            }
            catch
            {
                return Problem(READ_FAIL);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromForm] CreateQuestionPostModel request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            // Handle the image and audio files if they are provided
            if (request.ImageFile != null)
            {
                // Save the image file or process it
                // Example: var imagePath = Path.Combine("path-to-save", request.ImageFile.FileName);
                // using (var stream = new FileStream(imagePath, FileMode.Create))
                // {
                //     await request.ImageFile.CopyToAsync(stream);
                // }
            }

            if (request.AudioFile != null)
            {
                // Save the audio file or process it
                // Example: var audioPath = Path.Combine("path-to-save", request.AudioFile.FileName);
                // using (var stream = new FileStream(audioPath, FileMode.Create))
                // {
                //     await request.AudioFile.CopyToAsync(stream);
                // }
            }

            // Process other data
            // Example: Save the question and answers to the database

            return Ok();
        }

    }

    public class CreateQuestionPostModel
    {
        public string? QuestionContent { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
        public string? Explanation { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IFormFile? AudioFile { get; set; }
        public Guid UserId { get; set; }
        public Guid DifficultLevelId { get; set; }
        public Guid SubSubjectId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PointId { get; set; }
        public Guid PenaltyPointId { get; set; }
        public Guid BookId { get; set; }
    }

    public class AnswerModel
    {
        public string? Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid Id { get; set; }
    }

}
