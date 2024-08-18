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
    public class EducationLevelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EducationLevelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EducationLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationLevelDTO>>> GetEducationLevels()
        {
            try
            {
                return await _context.EducationLevels.OrderBy(x => x.Name).Select(x => new EducationLevelDTO
                {
                    EducationLevelId = x.EducationLevelId,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    SubSubjects = _context.SubSubjects.Where(ss => ss.EducationLevelId == x.EducationLevelId).ToList()
                }).ToListAsync();
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/EducationLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevelDTO>> GetEducationLevel(Guid id)
        {
            try
            {
                var record = await _context.EducationLevels.FindAsync(id);
                if (record == null) return Problem(RECORD_NOT_FOUND);
                return new EducationLevelDTO
                {
                    EducationLevelId = record.EducationLevelId,
                    Name = record.Name,
                    Description = record.Description,
                    CreatedAt = record.CreatedAt,
                    UpdatedAt = record.UpdatedAt,
                    SubSubjects = _context.SubSubjects.Where(ss => ss.EducationLevelId == record.EducationLevelId).ToList()
                };
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/EducationLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel(Guid id, EducationLevel educationLevel)
        {
            try
            {
                if (!EducationLevelExists(id)) return Problem(RECORD_NOT_FOUND);
                if (id != educationLevel.EducationLevelId) return Problem(ID_PARAM_NOT_MATCH);
                if (educationLevel.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(educationLevel)) return Problem(NAME_EXISTED);

                _context.Entry(educationLevel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Problem(EDIT_FAIL);
            }

            return NoContent();
        }

        // POST: api/EducationLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationLevel>> PostEducationLevel(EducationLevel educationLevel)
        {
            try
            {
                if (educationLevel.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(educationLevel)) return Problem(NAME_EXISTED);

                _context.EducationLevels.Add(educationLevel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEducationLevel", new { id = educationLevel.EducationLevelId }, educationLevel);
            }
            catch (Exception)
            {
                return Problem(ADD_FAIL);
            }
        }

        // DELETE: api/EducationLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel(Guid id)
        {
            var educationLevel = await _context.EducationLevels.FindAsync(id);
            if (educationLevel == null) return Problem(RECORD_NOT_FOUND);
            try
            {
                _context.EducationLevels.Remove(educationLevel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateException)
            {
                bool isSubjectHaveChild = _context.SubSubjects.Any(x => x.EducationLevelId == educationLevel.EducationLevelId);
                if (isSubjectHaveChild) return Problem("Môn học có Chương phụ thuộc!");
                return Problem(DELETE_FAIL);
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool EducationLevelExists(Guid id)
        {
            return (_context.EducationLevels?.Any(e => e.EducationLevelId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(EducationLevel educationLevel)
        {
            return (_context.EducationLevels?.Any(e => e.Name == educationLevel.Name && e.EducationLevelId != educationLevel.EducationLevelId)).GetValueOrDefault();
        }
    }
}
