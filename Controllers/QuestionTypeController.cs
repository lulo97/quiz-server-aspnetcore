using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend.Utils.Const;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionType>>> GetQuestionTypes()
        {
            try
            {
                return await _context.QuestionTypes.OrderBy(x => x.Name).ToListAsync();
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/QuestionType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionType>> GetQuestionType(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var questionType = await _context.QuestionTypes.FindAsync(id);
                if (questionType == null) return Problem(RECORD_NOT_FOUND);

                return questionType;
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/QuestionType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionType(Guid id, QuestionType questionType)
        {


            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                if (!QuestionTypeExists(id)) return Problem(RECORD_NOT_FOUND);
                if (id != questionType.QuestionTypeId) return Problem(ID_PARAM_NOT_MATCH);
                if (questionType.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(questionType)) return Problem(NAME_EXISTED);

                _context.Entry(questionType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem(EDIT_FAIL);
            }

            return NoContent();
        }

        // POST: api/QuestionType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionType>> PostQuestionType(QuestionType questionType)
        {
            try
            {
                if (questionType.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(questionType)) return Problem(NAME_EXISTED);

                _context.QuestionTypes.Add(questionType);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetQuestionType", new { id = questionType.QuestionTypeId }, questionType);
            }
            catch (Exception)
            {
                return Problem(ADD_FAIL);
            }
        }

        // DELETE: api/QuestionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionType(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var questionType = await _context.QuestionTypes.FindAsync(id);
                if (questionType == null) return Problem(RECORD_NOT_FOUND);

                _context.QuestionTypes.Remove(questionType);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool QuestionTypeExists(Guid id)
        {
            return (_context.QuestionTypes?.Any(e => e.QuestionTypeId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(QuestionType questionType)
        {
            return (_context.QuestionTypes?.Any(e => e.Name == questionType.Name && e.QuestionTypeId != questionType.QuestionTypeId)).GetValueOrDefault();
        }
    }
}
