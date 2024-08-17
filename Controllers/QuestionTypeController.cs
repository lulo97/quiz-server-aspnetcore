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
    public class QuestionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionType>>> GetQuestionTypes()
        {
          if (_context.QuestionTypes == null)
          {
              return Problem();
          }
            return await _context.QuestionTypes.ToListAsync();
        }

        // GET: api/QuestionType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionType>> GetQuestionType(Guid id)
        {
          if (_context.QuestionTypes == null)
          {
              return Problem();
          }
            var questionType = await _context.QuestionTypes.FindAsync(id);

            if (questionType == null)
            {
                return Problem();
            }

            return questionType;
        }

        // PUT: api/QuestionType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionType(Guid id, QuestionType questionType)
        {
            if (id != questionType.QuestionTypeId)
            {
                return Problem();
            }

            _context.Entry(questionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeExists(id))
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

        // POST: api/QuestionType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionType>> PostQuestionType(QuestionType questionType)
        {
          if (_context.QuestionTypes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.QuestionTypes'  is null.");
          }
            _context.QuestionTypes.Add(questionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionType", new { id = questionType.QuestionTypeId }, questionType);
        }

        // DELETE: api/QuestionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionType(Guid id)
        {
            if (_context.QuestionTypes == null)
            {
                return Problem();
            }
            var questionType = await _context.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return Problem();
            }

            _context.QuestionTypes.Remove(questionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionTypeExists(Guid id)
        {
            return (_context.QuestionTypes?.Any(e => e.QuestionTypeId == id)).GetValueOrDefault();
        }
    }
}
