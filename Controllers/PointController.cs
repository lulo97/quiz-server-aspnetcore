using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PointController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Point
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
            if (_context.Points == null)
            {
                return Problem();
            }
            return await _context.Points.OrderBy(x => x.Value).OrderBy(x => x.IsPenalty).ToListAsync();
        }

        // GET: api/Point/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(Guid id)
        {
            if (_context.Points == null)
            {
                return Problem();
            }
            var point = await _context.Points.FindAsync(id);

            if (point == null)
            {
                return Problem();
            }

            return point;
        }

        // PUT: api/Point/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoint(Guid id, Point point)
        {
            if (id != point.PointId)
            {
                return Problem();
            }
            if (IsHavePointWithSameValue(point.Value, point.IsPenalty)) return Problem("Loại điểm này đã có giá trị điểm tồn tại!");

            _context.Entry(point).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(id))
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

        // POST: api/Point
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(Point point)
        {
            if (_context.Points == null) return Problem("Entity set 'ApplicationDbContext.Points'  is null.");
            if (IsHavePointWithSameValue(point.Value, point.IsPenalty)) return Problem("Loại điểm này đã có giá trị điểm tồn tại!");
            _context.Points.Add(point);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoint", new { id = point.PointId }, point);
        }

        // DELETE: api/Point/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(Guid id)
        {
            if (_context.Points == null)
            {
                return Problem();
            }
            var point = await _context.Points.FindAsync(id);
            if (point == null)
            {
                return Problem();
            }

            _context.Points.Remove(point);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointExists(Guid id)
        {
            return (_context.Points?.Any(e => e.PointId == id)).GetValueOrDefault();
        }

        //In c# & is bitwise AND, which mean both side of expression is evaluated everytime
        //&& is conditional AND, if first expression is false then return false
        private bool IsHavePointWithSameValue(int Value, bool IsPenalty)
        {
            return (_context.Points?.Any(e => (e.Value == Value & e.IsPenalty == IsPenalty))).GetValueOrDefault();
        }
    }
}
