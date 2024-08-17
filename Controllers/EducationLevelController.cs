using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<EducationLevel>>> GetEducationLevels()
        {
            if (_context.EducationLevels == null)
            {
                return NotFound();
            }
            return await _context.EducationLevels.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/EducationLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevel>> GetEducationLevel(Guid id)
        {
            if (_context.EducationLevels == null)
            {
                return NotFound();
            }
            var educationLevel = await _context.EducationLevels.FindAsync(id);

            if (educationLevel == null)
            {
                return NotFound();
            }

            return educationLevel;
        }

        // PUT: api/EducationLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel(Guid id, EducationLevel educationLevel)
        {
            if (id != educationLevel.EducationLevelId)
            {
                return BadRequest();
            }
            if (educationLevel.Name == null) return Problem("Tên trống!");

            _context.Entry(educationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EducationLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationLevel>> PostEducationLevel(EducationLevel educationLevel)
        {
            if (_context.EducationLevels == null)
                return Problem("Entity set 'ApplicationDbContext.EducationLevels'  is null.");
            if (educationLevel.Name == null) return Problem("Tên trống!");
            if (IsHaveRecordWithSameName(educationLevel.Name)) return Problem("Tên đã tồn tại!");

            _context.EducationLevels.Add(educationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.EducationLevelId }, educationLevel);
        }

        // DELETE: api/EducationLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel(Guid id)
        {
            if (_context.EducationLevels == null)
            {
                return NotFound();
            }
            var educationLevel = await _context.EducationLevels.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _context.EducationLevels.Remove(educationLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationLevelExists(Guid id)
        {
            return (_context.EducationLevels?.Any(e => e.EducationLevelId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(string Name)
        {
            return (_context.EducationLevels?.Any(e => e.Name == Name)).GetValueOrDefault();
        }
    }
}
