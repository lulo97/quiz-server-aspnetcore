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
    public class QuizQuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizQuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuizQuestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizQuestion>>> GetQuizQuestions()
        {
          if (_context.QuizQuestions == null)
          {
              return Problem();
          }
            return await _context.QuizQuestions.ToListAsync();
        }

        // GET: api/QuizQuestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizQuestion>> GetQuizQuestion(Guid id)
        {
          if (_context.QuizQuestions == null)
          {
              return Problem();
          }
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);

            if (quizQuestion == null)
            {
                return Problem();
            }

            return quizQuestion;
        }

        // PUT: api/QuizQuestion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizQuestion(Guid id, QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.QuizQuestionId)
            {
                return Problem();
            }

            _context.Entry(quizQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizQuestionExists(id))
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

        // POST: api/QuizQuestion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizQuestion>> PostQuizQuestion(QuizQuestion quizQuestion)
        {
          if (_context.QuizQuestions == null)
          {
              return Problem("Entity set 'ApplicationDbContext.QuizQuestions'  is null.");
          }
            _context.QuizQuestions.Add(quizQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizQuestion", new { id = quizQuestion.QuizQuestionId }, quizQuestion);
        }

        // DELETE: api/QuizQuestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(Guid id)
        {
            if (_context.QuizQuestions == null)
            {
                return Problem();
            }
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);
            if (quizQuestion == null)
            {
                return Problem();
            }

            _context.QuizQuestions.Remove(quizQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizQuestionExists(Guid id)
        {
            return (_context.QuizQuestions?.Any(e => e.QuizQuestionId == id)).GetValueOrDefault();
        }
    }
}
