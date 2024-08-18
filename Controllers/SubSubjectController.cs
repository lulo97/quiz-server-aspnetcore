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
    public class SubSubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubSubject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubSubjectDTO>>> GetSubSubjects()
        {
            try
            {
                return await _context.SubSubjects
                    .Include(x => x.Subject)
                    .Include(x => x.EducationLevel)
                    .OrderBy(x => x.Name)
                    .Select(x => new SubSubjectDTO
                    {
                        SubSubjectId = x.SubSubjectId,
                        SubjectId = x.SubjectId,
                        EducationLevelId = x.EducationLevelId,
                        Name = x.Name,
                        Description = x.Description,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt,
                        SubjectName = x.Subject != null ? x.Subject.Name : null,
                        EducationLevelName = x.EducationLevel != null ? x.EducationLevel.Name : null
                    })
                    .ToListAsync();
            }
            catch
            {
                return Problem(READ_FAIL);
            }

        }

        // GET: api/SubSubject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubSubject>> GetSubSubject(Guid id)
        {
            try
            {
                var subSubject = await _context.SubSubjects.FindAsync(id);
                if (subSubject == null) return Problem(READ_FAIL);
                return subSubject;
            }
            catch { return Problem(READ_FAIL); }
        }

        // PUT: api/SubSubject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubSubject(Guid id, SubSubject subSubject)
        {
            try
            {
                if (subSubject.Name == null) return Problem(NAME_NULL);
                if (id != subSubject.SubSubjectId) return Problem(ID_PARAM_NOT_MATCH);
                if (!SubSubjectExists(id)) return Problem(RECORD_NOT_FOUND);
                if (subSubject.SubSubjectId == Guid.Empty) return Problem(SUBJECT_ID_NULL);
                if (subSubject.EducationLevelId == Guid.Empty) return Problem(EDUCATION_LEVEL_ID_NULL);
                if (IsHaveRecordWithSame(subSubject)) return Problem(RECORD_CONTENT_EXISTED);

                _context.Entry(subSubject).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch
            {
                return Problem(EDIT_FAIL);
            }
        }

        // POST: api/SubSubject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubSubject>> PostSubSubject(SubSubject subSubject)
        {
            try
            {
                if (subSubject.Name == null) return Problem(NAME_NULL);
                if (subSubject.SubSubjectId == Guid.Empty) return Problem(SUBJECT_ID_NULL);
                if (subSubject.EducationLevelId == Guid.Empty) return Problem(EDUCATION_LEVEL_ID_NULL);
                if (IsHaveRecordWithSame(subSubject)) return Problem(RECORD_CONTENT_EXISTED);

                _context.SubSubjects.Add(subSubject);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSubSubject", new { id = subSubject.SubSubjectId }, subSubject);
            }
            catch
            {
                return Problem(ADD_FAIL);
            }

        }

        // DELETE: api/SubSubject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubSubject(Guid id)
        {
            try
            {
                var subSubject = await _context.SubSubjects.FindAsync(id);
                if (subSubject == null) return Problem(READ_FAIL);
                _context.SubSubjects.Remove(subSubject);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool SubSubjectExists(Guid id)
        {
            return (_context.SubSubjects?.Any(e => e.SubSubjectId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSame(SubSubject subSubject)
        {
            //Check if combination Name, Subject, Education already exist
            return (_context.SubSubjects?.Any(
                    x => x.Name == subSubject.Name
                && x.SubjectId == subSubject.SubjectId
                && x.EducationLevelId == subSubject.EducationLevelId
                && x.SubSubjectId != subSubject.SubSubjectId
            )).GetValueOrDefault();
        }
    }
}
