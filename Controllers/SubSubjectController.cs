using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

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
        public async Task<ActionResult<IEnumerable<SubSubject>>> GetSubSubjects()
        {
          if (_context.SubSubjects == null)
          {
              return NotFound();
          }
            return await _context.SubSubjects.OrderBy(x => x.Name).ToListAsync();
        }

        // GET: api/SubSubject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubSubject>> GetSubSubject(Guid id)
        {
          if (_context.SubSubjects == null)
          {
              return NotFound();
          }
            var subSubject = await _context.SubSubjects.FindAsync(id);

            if (subSubject == null)
            {
                return NotFound();
            }

            return subSubject;
        }

        // PUT: api/SubSubject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubSubject(Guid id, SubSubject subSubject)
        {
            if (id != subSubject.SubSubjectId)
            {
                return BadRequest();
            }

            _context.Entry(subSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubSubjectExists(id))
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

        // POST: api/SubSubject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubSubject>> PostSubSubject(SubSubject subSubject)
        {
          if (_context.SubSubjects == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SubSubjects'  is null.");
          }
            _context.SubSubjects.Add(subSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubSubject", new { id = subSubject.SubSubjectId }, subSubject);
        }

        // DELETE: api/SubSubject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubSubject(Guid id)
        {
            if (_context.SubSubjects == null)
            {
                return NotFound();
            }
            var subSubject = await _context.SubSubjects.FindAsync(id);
            if (subSubject == null)
            {
                return NotFound();
            }

            _context.SubSubjects.Remove(subSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubSubjectExists(Guid id)
        {
            return (_context.SubSubjects?.Any(e => e.SubSubjectId == id)).GetValueOrDefault();
        }
    }
}
