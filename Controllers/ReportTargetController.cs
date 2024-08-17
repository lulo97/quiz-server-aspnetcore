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
    public class ReportTargetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportTargetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReportTarget
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportTarget>>> GetReportTargets()
        {
          if (_context.ReportTargets == null)
          {
              return Problem();
          }
            return await _context.ReportTargets.ToListAsync();
        }

        // GET: api/ReportTarget/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportTarget>> GetReportTarget(Guid id)
        {
          if (_context.ReportTargets == null)
          {
              return Problem();
          }
            var reportTarget = await _context.ReportTargets.FindAsync(id);

            if (reportTarget == null)
            {
                return Problem();
            }

            return reportTarget;
        }

        // PUT: api/ReportTarget/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportTarget(Guid id, ReportTarget reportTarget)
        {
            if (id != reportTarget.ReportTargetId)
            {
                return Problem();
            }

            _context.Entry(reportTarget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportTargetExists(id))
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

        // POST: api/ReportTarget
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportTarget>> PostReportTarget(ReportTarget reportTarget)
        {
          if (_context.ReportTargets == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ReportTargets'  is null.");
          }
            _context.ReportTargets.Add(reportTarget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportTarget", new { id = reportTarget.ReportTargetId }, reportTarget);
        }

        // DELETE: api/ReportTarget/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportTarget(Guid id)
        {
            if (_context.ReportTargets == null)
            {
                return Problem();
            }
            var reportTarget = await _context.ReportTargets.FindAsync(id);
            if (reportTarget == null)
            {
                return Problem();
            }

            _context.ReportTargets.Remove(reportTarget);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportTargetExists(Guid id)
        {
            return (_context.ReportTargets?.Any(e => e.ReportTargetId == id)).GetValueOrDefault();
        }
    }
}
