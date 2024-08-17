using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultLevelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DifficultLevelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DifficultLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DifficultLevel>>> GetDifficultLevels()
        {
            if (_context.DifficultLevels == null)
            {
                return Problem();
            }
            return await _context.DifficultLevels.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/DifficultLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DifficultLevel>> GetDifficultLevel(Guid id)
        {
            if (_context.DifficultLevels == null)
            {
                return Problem();
            }
            var difficultLevel = await _context.DifficultLevels.FindAsync(id);

            if (difficultLevel == null)
            {
                return Problem();
            }

            return difficultLevel;
        }

        // PUT: api/DifficultLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifficultLevel(Guid id, DifficultLevel difficultLevel)
        {
            if (id != difficultLevel.DifficultLevelId)
            {
                return Problem();
            }

            if (difficultLevel.Name == null) return Problem(NAME_NULL);

            _context.Entry(difficultLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifficultLevelExists(id))
                {
                    return Problem();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DifficultLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DifficultLevel>> PostDifficultLevel(DifficultLevel difficultLevel)
        {
            if (_context.DifficultLevels == null)
                return Problem("Entity set 'ApplicationDbContext.DifficultLevels'  is null.");
            if (difficultLevel.Name == null) return Problem(NAME_NULL);
            if (IsHaveRecordWithSameName(difficultLevel.Name)) return Problem(NAME_EXISTED);

            _context.DifficultLevels.Add(difficultLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDifficultLevel", new { id = difficultLevel.DifficultLevelId }, difficultLevel);
        }

        // DELETE: api/DifficultLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficultLevel(Guid id)
        {
            if (_context.DifficultLevels == null)
            {
                return Problem();
            }
            var difficultLevel = await _context.DifficultLevels.FindAsync(id);
            if (difficultLevel == null)
            {
                return Problem();
            }

            _context.DifficultLevels.Remove(difficultLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DifficultLevelExists(Guid id)
        {
            return (_context.DifficultLevels?.Any(e => e.DifficultLevelId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(string Name)
        {
            return (_context.DifficultLevels?.Any(e => e.Name == Name)).GetValueOrDefault();
        }
    }
}
