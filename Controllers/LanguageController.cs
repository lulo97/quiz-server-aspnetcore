using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Utils.cón
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
            try
            {
                if (_context.Languages == null)
                {
                    return Problem();
                }
                return await _context.Languages.OrderBy(x => x.Name).ToListAsync();
            } catch { }

        }

        // GET: api/Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(Guid id)
        {
            if (_context.Languages == null)
            {
                return Problem();
            }
            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                return Problem();
            }

            return language;
        }

        // PUT: api/Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(Guid id, Language language)
        {
            try
            {
                if (id != language.LanguageId) return Problem("id không khớp mã bản ghi");
                if (!LanguageExists(id)) return Problem("Không tìm thấy mã bản ghi");
                if (language.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(language)) return Problem(NAME_EXISTED);

                _context.Entry(language).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem("Sửa thất bại");
            }
        }

        // POST: api/Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Language>> PostLanguage(Language language)
        {
            try
            {
                if (_context.Languages == null)
                    return Problem("Entity set 'ApplicationDbContext.Languages'  is null.");
                if (language.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(language)) return Problem(NAME_EXISTED);

                _context.Languages.Add(language);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLanguage", new { id = language.LanguageId }, language);
            }
            catch
            {
                return Problem("Thêm thất bại!");
            }

        }

        // DELETE: api/Language/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            if (_context.Languages == null)
            {
                return Problem();
            }
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return Problem();
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(Guid id)
        {
            return (_context.Languages?.Any(e => e.LanguageId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(Language language)
        {
            return (_context.Languages?.Any(e => e.Name == language.Name && e.LanguageId != language.LanguageId)).GetValueOrDefault();
        }
    }
}
