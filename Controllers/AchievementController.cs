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
    public class AchievementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AchievementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Achievement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achievement>>> GetAchievements()
        {
          if (_context.Achievements == null)
          {
              return Problem();
          }
            return await _context.Achievements.ToListAsync();
        }

        // GET: api/Achievement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achievement>> GetAchievement(Guid id)
        {
          if (_context.Achievements == null)
          {
              return Problem();
          }
            var achievement = await _context.Achievements.FindAsync(id);

            if (achievement == null)
            {
                return Problem();
            }

            return achievement;
        }

        // PUT: api/Achievement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchievement(Guid id, Achievement achievement)
        {
            if (id != achievement.AchievementId)
            {
                return Problem();
            }

            _context.Entry(achievement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchievementExists(id))
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

        // POST: api/Achievement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achievement>> PostAchievement(Achievement achievement)
        {
          if (_context.Achievements == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Achievements'  is null.");
          }
            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchievement", new { id = achievement.AchievementId }, achievement);
        }

        // DELETE: api/Achievement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(Guid id)
        {
            if (_context.Achievements == null)
            {
                return Problem();
            }
            var achievement = await _context.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return Problem();
            }

            _context.Achievements.Remove(achievement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchievementExists(Guid id)
        {
            return (_context.Achievements?.Any(e => e.AchievementId == id)).GetValueOrDefault();
        }
    }
}
