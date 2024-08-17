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
    public class PlayController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Play
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Play>>> GetPlays()
        {
          if (_context.Plays == null)
          {
              return NotFound();
          }
            return await _context.Plays.ToListAsync();
        }

        // GET: api/Play/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Play>> GetPlay(Guid id)
        {
          if (_context.Plays == null)
          {
              return NotFound();
          }
            var play = await _context.Plays.FindAsync(id);

            if (play == null)
            {
                return NotFound();
            }

            return play;
        }

        // PUT: api/Play/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlay(Guid id, Play play)
        {
            if (id != play.PlayId)
            {
                return BadRequest();
            }

            _context.Entry(play).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayExists(id))
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

        // POST: api/Play
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Play>> PostPlay(Play play)
        {
          if (_context.Plays == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Plays'  is null.");
          }
            _context.Plays.Add(play);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlay", new { id = play.PlayId }, play);
        }

        // DELETE: api/Play/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlay(Guid id)
        {
            if (_context.Plays == null)
            {
                return NotFound();
            }
            var play = await _context.Plays.FindAsync(id);
            if (play == null)
            {
                return NotFound();
            }

            _context.Plays.Remove(play);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayExists(Guid id)
        {
            return (_context.Plays?.Any(e => e.PlayId == id)).GetValueOrDefault();
        }
    }
}
