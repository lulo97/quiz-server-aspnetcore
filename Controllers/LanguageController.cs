using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            if (_context.Languages == null)
            {
                return NotFound();
            }
            return await _context.Languages.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(Guid id)
        {
            if (_context.Languages == null)
            {
                return NotFound();
            }
            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // PUT: api/Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, Language language)
        {
            if (id != language.LanguageId)
            {
                return BadRequest();
            }

            if (language.Name == null) return Problem("Tên trống!");

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(Language language)
        {
            if (_context.Languages == null)
                return Problem("Entity set 'ApplicationDbContext.Languages'  is null.");
            if (language.Name == null) return Problem("Tên trống!");
            if (IsHaveRecordWithSameName(language.Name)) return Problem("Tên đã tồn tại!");

            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguage", new { id = language.LanguageId }, language);
        }

        // DELETE: api/Language/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            if (_context.Languages == null)
            {
                return NotFound();
            }
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(Guid id)
        {
            return (_context.Languages?.Any(e => e.LanguageId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(string Name)
        {
            return (_context.Languages?.Any(e => e.Name == Name)).GetValueOrDefault();
        }
    }
}
