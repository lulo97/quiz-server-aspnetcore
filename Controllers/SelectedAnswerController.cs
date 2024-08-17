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
    public class SelectedAnswerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SelectedAnswerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SelectedAnswer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SelectedAnswer>>> GetSelectedAnswers()
        {
          if (_context.SelectedAnswers == null)
          {
              return Problem();
          }
            return await _context.SelectedAnswers.ToListAsync();
        }

        // GET: api/SelectedAnswer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SelectedAnswer>> GetSelectedAnswer(Guid id)
        {
          if (_context.SelectedAnswers == null)
          {
              return Problem();
          }
            var selectedAnswer = await _context.SelectedAnswers.FindAsync(id);

            if (selectedAnswer == null)
            {
                return Problem();
            }

            return selectedAnswer;
        }

        // PUT: api/SelectedAnswer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelectedAnswer(Guid id, SelectedAnswer selectedAnswer)
        {
            if (id != selectedAnswer.SelectedAnswerId)
            {
                return Problem();
            }

            _context.Entry(selectedAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedAnswerExists(id))
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

        // POST: api/SelectedAnswer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SelectedAnswer>> PostSelectedAnswer(SelectedAnswer selectedAnswer)
        {
          if (_context.SelectedAnswers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SelectedAnswers'  is null.");
          }
            _context.SelectedAnswers.Add(selectedAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSelectedAnswer", new { id = selectedAnswer.SelectedAnswerId }, selectedAnswer);
        }

        // DELETE: api/SelectedAnswer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelectedAnswer(Guid id)
        {
            if (_context.SelectedAnswers == null)
            {
                return Problem();
            }
            var selectedAnswer = await _context.SelectedAnswers.FindAsync(id);
            if (selectedAnswer == null)
            {
                return Problem();
            }

            _context.SelectedAnswers.Remove(selectedAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelectedAnswerExists(Guid id)
        {
            return (_context.SelectedAnswers?.Any(e => e.SelectedAnswerId == id)).GetValueOrDefault();
        }
    }
}
