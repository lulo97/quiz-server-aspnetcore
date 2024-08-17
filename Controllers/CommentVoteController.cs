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
    public class CommentVoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentVoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentVote
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentVote>>> GetCommentVotes()
        {
          if (_context.CommentVotes == null)
          {
              return Problem();
          }
            return await _context.CommentVotes.ToListAsync();
        }

        // GET: api/CommentVote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentVote>> GetCommentVote(Guid id)
        {
          if (_context.CommentVotes == null)
          {
              return Problem();
          }
            var commentVote = await _context.CommentVotes.FindAsync(id);

            if (commentVote == null)
            {
                return Problem();
            }

            return commentVote;
        }

        // PUT: api/CommentVote/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentVote(Guid id, CommentVote commentVote)
        {
            if (id != commentVote.CommentVoteId)
            {
                return Problem();
            }

            _context.Entry(commentVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentVoteExists(id))
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

        // POST: api/CommentVote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentVote>> PostCommentVote(CommentVote commentVote)
        {
          if (_context.CommentVotes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.CommentVotes'  is null.");
          }
            _context.CommentVotes.Add(commentVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentVote", new { id = commentVote.CommentVoteId }, commentVote);
        }

        // DELETE: api/CommentVote/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentVote(Guid id)
        {
            if (_context.CommentVotes == null)
            {
                return Problem();
            }
            var commentVote = await _context.CommentVotes.FindAsync(id);
            if (commentVote == null)
            {
                return Problem();
            }

            _context.CommentVotes.Remove(commentVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentVoteExists(Guid id)
        {
            return (_context.CommentVotes?.Any(e => e.CommentVoteId == id)).GetValueOrDefault();
        }
    }
}
