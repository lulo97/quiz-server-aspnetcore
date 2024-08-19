using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend.Utils.Const;

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
            try
            {
                return await _context.Points.OrderBy(x => x.IsPenalty).ThenBy(x => x.Value).ToListAsync();
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/Point/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var point = await _context.Points.FindAsync(id);
                if (point == null) return Problem(RECORD_NOT_FOUND);
                return point;
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/Point/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoint(Guid id, Point point)
        {

            try
            {
                if (id != Guid.Empty) return Problem(ID_NULL);
                if (id != point.PointId) return Problem(ID_PARAM_NOT_MATCH);
                if (!PointExists(id)) return Problem(RECORD_NOT_FOUND);
                if (IsHavePointWithSameValue(point)) return Problem(RECORD_CONTENT_EXISTED);

                _context.Entry(point).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(EDIT_FAIL);
            }
        }

        // POST: api/Point
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(Point point)
        {
            try
            {
                if (IsHavePointWithSameValue(point)) return Problem(RECORD_CONTENT_EXISTED);
                _context.Points.Add(point);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPoint", new { id = point.PointId }, point);
            }
            catch (Exception)
            {
                return Problem(ADD_FAIL);
            }
        }

        // DELETE: api/Point/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(Guid id)
        {
            try
            {
                if (id != Guid.Empty) return Problem(ID_NULL);
                var point = await _context.Points.FindAsync(id);
                if (point == null) return Problem(RECORD_NOT_FOUND);
                if (IsHavePointWithSameValue(point)) return Problem(RECORD_CONTENT_EXISTED);

                _context.Points.Remove(point);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool PointExists(Guid id)
        {
            return (_context.Points?.Any(e => e.PointId == id)).GetValueOrDefault();
        }

        //In c# & is bitwise AND, which mean both side of expression is evaluated everytime
        //&& is conditional AND, if first expression is false then return false
        private bool IsHavePointWithSameValue(Point point)
        {
            return (_context.Points?.Any(e => (e.Value == point.Value & e.IsPenalty == point.IsPenalty))).GetValueOrDefault();
        }
    }
}
