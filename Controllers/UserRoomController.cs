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
    public class UserRoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserRoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoom>>> GetUserRooms()
        {
          if (_context.UserRooms == null)
          {
              return NotFound();
          }
            return await _context.UserRooms.ToListAsync();
        }

        // GET: api/UserRoom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoom>> GetUserRoom(Guid id)
        {
          if (_context.UserRooms == null)
          {
              return NotFound();
          }
            var userRoom = await _context.UserRooms.FindAsync(id);

            if (userRoom == null)
            {
                return NotFound();
            }

            return userRoom;
        }

        // PUT: api/UserRoom/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoom(Guid id, UserRoom userRoom)
        {
            if (id != userRoom.UserRoomId)
            {
                return BadRequest();
            }

            _context.Entry(userRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoomExists(id))
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

        // POST: api/UserRoom
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoom>> PostUserRoom(UserRoom userRoom)
        {
          if (_context.UserRooms == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserRooms'  is null.");
          }
            _context.UserRooms.Add(userRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRoom", new { id = userRoom.UserRoomId }, userRoom);
        }

        // DELETE: api/UserRoom/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoom(Guid id)
        {
            if (_context.UserRooms == null)
            {
                return NotFound();
            }
            var userRoom = await _context.UserRooms.FindAsync(id);
            if (userRoom == null)
            {
                return NotFound();
            }

            _context.UserRooms.Remove(userRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoomExists(Guid id)
        {
            return (_context.UserRooms?.Any(e => e.UserRoomId == id)).GetValueOrDefault();
        }
    }
}
