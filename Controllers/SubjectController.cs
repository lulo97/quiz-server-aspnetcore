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
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetSubjects()
        {
            try
            {
                return await _context.Subjects.OrderBy(x => x.Name).Select(x => new SubjectDTO
                {
                    SubjectId = x.SubjectId,
                    Name = x.Name,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    SubSubjects = _context.SubSubjects.Where(ss => ss.SubjectId == x.SubjectId).ToList()
                }).ToListAsync();
            }
            catch
            {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> GetSubject(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var record = await _context.Subjects.FindAsync(id);
                if (record == null) return Problem();

                return new SubjectDTO
                {
                    SubjectId = record.SubjectId,
                    Name = record.Name,
                    Description = record.Description,
                    CreatedAt = record.CreatedAt,
                    UpdatedAt = record.UpdatedAt,
                    SubSubjects = _context.SubSubjects.Where(ss => ss.SubjectId == record.SubjectId).ToList()
                };
            }
            catch
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/Subject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(Guid id, Subject subject)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                if (!SubjectExists(id)) return Problem(RECORD_NOT_FOUND);
                if (id != subject.SubjectId) return Problem(ID_PARAM_NOT_MATCH);
                if (subject.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(subject)) return Problem(NAME_EXISTED);

                subject.UpdatedAt = DateTime.Now;

                _context.Entry(subject).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return Problem(EDIT_FAIL);
            }
        }

        // POST: api/Subject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            try
            {
                if (subject.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(subject)) return Problem(NAME_EXISTED);

                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subject);
            }
            catch
            {
                return Problem(ADD_FAIL);
            }
        }

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            if (id == Guid.Empty) return Problem(ID_NULL);
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return Problem(READ_FAIL);
            try
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException)
            {
                bool isSubjectHaveChild = _context.SubSubjects.Any(x => x.SubjectId == subject.SubjectId);
                if (isSubjectHaveChild) return Problem("Môn học có Chương phụ thuộc!");
                return Problem(DELETE_FAIL);
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }

        }

        private bool SubjectExists(Guid id)
        {
            return (_context.Subjects?.Any(e => e.SubjectId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(Subject subject)
        {
            return (_context.Subjects?.Any(e => e.Name == subject.Name && e.SubjectId != subject.SubjectId)).GetValueOrDefault();
        }
    }
}
