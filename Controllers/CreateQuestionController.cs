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
    }
}
