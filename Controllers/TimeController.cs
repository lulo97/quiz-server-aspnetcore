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
    public class TimeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Time
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimes()
        {
          if (_context.Times == null)
          {
              return Problem();
          }
            return await _context.Times.ToListAsync();
        }

        // GET: api/Time/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(Guid id)
        {
          if (_context.Times == null)
          {
              return Problem();
          }
            var time = await _context.Times.FindAsync(id);

            if (time == null)
            {
                return Problem();
            }

            return time;
        }

        // PUT: api/Time/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTime(Guid id, Time time)
        {
            if (id != time.TimeId)
            {
                return Problem();
            }

            _context.Entry(time).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Time
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Time>> PostTime(Time time)
        {
          if (_context.Times == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Times'  is null.");
          }
            _context.Times.Add(time);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTime", new { id = time.TimeId }, time);
        }

        // DELETE: api/Time/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime(Guid id)
        {
            if (_context.Times == null)
            {
                return Problem();
            }
            var time = await _context.Times.FindAsync(id);
            if (time == null)
            {
                return Problem();
            }

            _context.Times.Remove(time);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeExists(Guid id)
        {
            return (_context.Times?.Any(e => e.TimeId == id)).GetValueOrDefault();
        }
    }
}
