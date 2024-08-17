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
    public class FollowController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FollowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Follow
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetFollows()
        {
          if (_context.Follows == null)
          {
              return NotFound();
          }
            return await _context.Follows.ToListAsync();
        }

        // GET: api/Follow/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(Guid id)
        {
          if (_context.Follows == null)
          {
              return NotFound();
          }
            var follow = await _context.Follows.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // PUT: api/Follow/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollow(Guid id, Follow follow)
        {
            if (id != follow.FollowId)
            {
                return BadRequest();
            }

            _context.Entry(follow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowExists(id))
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

        // POST: api/Follow
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(Follow follow)
        {
          if (_context.Follows == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Follows'  is null.");
          }
            _context.Follows.Add(follow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollow", new { id = follow.FollowId }, follow);
        }

        // DELETE: api/Follow/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollow(Guid id)
        {
            if (_context.Follows == null)
            {
                return NotFound();
            }
            var follow = await _context.Follows.FindAsync(id);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FollowExists(Guid id)
        {
            return (_context.Follows?.Any(e => e.FollowId == id)).GetValueOrDefault();
        }
    }
}
