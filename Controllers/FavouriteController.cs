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
    public class FavouriteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavouriteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Favourite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourite>>> GetFavourites()
        {
          if (_context.Favourites == null)
          {
              return NotFound();
          }
            return await _context.Favourites.ToListAsync();
        }

        // GET: api/Favourite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favourite>> GetFavourite(Guid id)
        {
          if (_context.Favourites == null)
          {
              return NotFound();
          }
            var favourite = await _context.Favourites.FindAsync(id);

            if (favourite == null)
            {
                return NotFound();
            }

            return favourite;
        }

        // PUT: api/Favourite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavourite(Guid id, Favourite favourite)
        {
            if (id != favourite.FavouriteId)
            {
                return BadRequest();
            }

            _context.Entry(favourite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteExists(id))
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

        // POST: api/Favourite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourite>> PostFavourite(Favourite favourite)
        {
          if (_context.Favourites == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Favourites'  is null.");
          }
            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavourite", new { id = favourite.FavouriteId }, favourite);
        }

        // DELETE: api/Favourite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(Guid id)
        {
            if (_context.Favourites == null)
            {
                return NotFound();
            }
            var favourite = await _context.Favourites.FindAsync(id);
            if (favourite == null)
            {
                return NotFound();
            }

            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteExists(Guid id)
        {
            return (_context.Favourites?.Any(e => e.FavouriteId == id)).GetValueOrDefault();
        }
    }
}
