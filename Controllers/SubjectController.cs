using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            try
            {
                if (_context.Subjects == null) return NotFound();
                return await _context.Subjects.OrderBy(x => x.Name).ToListAsync();
            } catch
            {
                return Problem("Lấy bản ghi thất bại!");
            }
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(Guid id)
        {
            try
            {
                if (_context.Subjects == null) return NotFound();
                var subject = await _context.Subjects.FindAsync(id);
                if (subject == null) return NotFound();
                
                return subject;
            } catch
            {
                return Problem("Lấy bản ghi thất bại!");
            }
        }

        // PUT: api/Subject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(Guid id, Subject subject)
        {
            try
            {
                if (!SubjectExists(id)) return NotFound("Mã không tồn tại!");
                if (id != subject.SubjectId) return BadRequest("id không trùng mã bản ghi!");
                if (subject.Name == null) return BadRequest("Tên trống!");

                subject.UpdatedAt = DateTime.Now;

                _context.Entry(subject).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return Problem("Sửa thất bại!");
            }
        }

        // POST: api/Subject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            try
            {
                if (_context.Subjects == null) return Problem("Entity set 'ApplicationDbContext.Subjects'  is null.");
                if (subject.Name == null) return BadRequest("Tên trống!");
                //if (IsHaveRecordWithSameName(subject.Name)) return Problem("Tên đã tồn tại!");

                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subject);
            }
            catch
            {
                return Problem("Thêm thất bại");
            }
        }

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            try
            {
                if (_context.Subjects == null) return NotFound();
                
                var subject = await _context.Subjects.FindAsync(id);
                if (subject == null) return NotFound("Lấy bản ghi thất bại");
                
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return Problem("Xóa thất bại");
            }

        }

        private bool SubjectExists(Guid id)
        {
            return (_context.Subjects?.Any(e => e.SubjectId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(string Name)
        {
            return (_context.Subjects?.Any(e => e.Name == Name)).GetValueOrDefault();
        }
    }
}
