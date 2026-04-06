using LibraryManagementApi.Models;
using LibraryManagementApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(LibraryDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            _logger.LogInformation("Retrieving all books.");
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            _logger.LogInformation("Retrieving book with ID: {Id}", id);
            
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                _logger.LogWarning("Book with ID: {Id} was not found.", id);
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _logger.LogInformation("Adding a new book: {Title}", book.Title);
            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                _logger.LogWarning("Put Request ID: {Id} does not match Book ID: {BookId}", id, book.Id);
                return BadRequest();
            }

            _logger.LogInformation("Updating book with ID: {Id}", id);
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    _logger.LogWarning("Concurrent update failed; Book with ID: {Id} not found.", id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // Simulate forced exception for testing if requested
            if (id == -1)
            {
                _logger.LogInformation("Simulating an exception for ID -1");
                throw new Exception("This is a simulated critical database failure exception.");
            }

            _logger.LogInformation("Attempting to delete book with ID: {Id}", id);
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning("Delete failed; Book with ID: {Id} not found.", id);
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Successfully deleted book with ID: {Id}", id);
            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
