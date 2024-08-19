using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Backend.Utils.Const;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                return await _context.Books.OrderBy(x => x.Name).ToListAsync();
            } catch {
                return Problem(READ_FAIL);
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var record = await _context.Books.FindAsync(id);
                if (record == null) return Problem(RECORD_NOT_FOUND);
                return record;
            }
            catch (Exception)
            {
                return Problem(READ_FAIL);
            }
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Book book)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                if (id != book.BookId) return Problem(ID_PARAM_NOT_MATCH);
                if (!BookExists(id)) return Problem(RECORD_NOT_FOUND);
                if (book.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(book)) return Problem(NAME_EXISTED);

                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem("Sửa thất bại");
            }
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            try
            {
                if (book.Name == null) return Problem(NAME_NULL);
                if (IsHaveRecordWithSameName(book)) return Problem(NAME_EXISTED);

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBook", new { id = book.BookId }, book);
            }
            catch
            {
                return Problem("Thêm thất bại!");
            }

        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return Problem(ID_NULL);
                var Book = await _context.Books.FindAsync(id);
                if (Book == null) return Problem(RECORD_NOT_FOUND);

                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return Problem(DELETE_FAIL);
            }
        }

        private bool BookExists(Guid id)
        {
            return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }

        private bool IsHaveRecordWithSameName(Book Book)
        {
            return (_context.Books?.Any(e => e.Name == Book.Name && e.BookId != Book.BookId)).GetValueOrDefault();
        }
    }
}
