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
    public class ReportReasonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportReasonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReportReason
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportReason>>> GetReportReasons()
        {
          if (_context.ReportReasons == null)
          {
              return NotFound();
          }
            return await _context.ReportReasons.ToListAsync();
        }

        // GET: api/ReportReason/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportReason>> GetReportReason(Guid id)
        {
          if (_context.ReportReasons == null)
          {
              return NotFound();
          }
            var reportReason = await _context.ReportReasons.FindAsync(id);

            if (reportReason == null)
            {
                return NotFound();
            }

            return reportReason;
        }

        // PUT: api/ReportReason/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportReason(Guid id, ReportReason reportReason)
        {
            if (id != reportReason.ReportReasonId)
            {
                return BadRequest();
            }

            _context.Entry(reportReason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportReasonExists(id))
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

        // POST: api/ReportReason
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportReason>> PostReportReason(ReportReason reportReason)
        {
          if (_context.ReportReasons == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ReportReasons'  is null.");
          }
            _context.ReportReasons.Add(reportReason);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportReason", new { id = reportReason.ReportReasonId }, reportReason);
        }

        // DELETE: api/ReportReason/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportReason(Guid id)
        {
            if (_context.ReportReasons == null)
            {
                return NotFound();
            }
            var reportReason = await _context.ReportReasons.FindAsync(id);
            if (reportReason == null)
            {
                return NotFound();
            }

            _context.ReportReasons.Remove(reportReason);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportReasonExists(Guid id)
        {
            return (_context.ReportReasons?.Any(e => e.ReportReasonId == id)).GetValueOrDefault();
        }
    }
}
