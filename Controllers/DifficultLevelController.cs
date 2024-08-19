using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend.Utils.Const;

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
            try
            {
                return await _context.DifficultLevels.OrderBy(x => x.Name).ToListAsync();

            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/DifficultLevel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DifficultLevel>> GetDifficultLevel(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var difficultLevel = await _context.DifficultLevels.FindAsync(id);
                if (difficultLevel == null) return Problem(RECORD_NOT_FOUND);
                return difficultLevel;
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/DifficultLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifficultLevel(Guid id, DifficultLevel difficultLevel)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                if (!DifficultLevelExists(id)) return Problem(RECORD_NOT_FOUND);
                if (id != difficultLevel.DifficultLevelId) return Problem(ID_PARAM_NOT_MATCH);
                if (difficultLevel.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(difficultLevel)) return Problem(NAME_EXISTED);

                _context.Entry(difficultLevel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return Problem(EDIT_FAIL);
            }

            return NoContent();
        }

        // POST: api/DifficultLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DifficultLevel>> PostDifficultLevel(DifficultLevel difficultLevel)
        {
            try
            {
                if (difficultLevel.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(difficultLevel)) return Problem(NAME_EXISTED);

                _context.DifficultLevels.Add(difficultLevel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDifficultLevel", new { id = difficultLevel.DifficultLevelId }, difficultLevel);
            }
            catch (Exception)
            {
                return Problem(ADD_FAIL);
            }
        }

        // DELETE: api/DifficultLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficultLevel(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var difficultLevel = await _context.DifficultLevels.FindAsync(id);
                if (difficultLevel == null) return Problem(RECORD_NOT_FOUND);

                _context.DifficultLevels.Remove(difficultLevel);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool DifficultLevelExists(Guid id)
        {
            return (_context.DifficultLevels?.Any(e => e.DifficultLevelId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(DifficultLevel difficultLevel)
        {
            return (_context.DifficultLevels?.Any(e => e.Name == difficultLevel.Name && e.DifficultLevelId != difficultLevel.DifficultLevelId)).GetValueOrDefault();
        }
    }
}
