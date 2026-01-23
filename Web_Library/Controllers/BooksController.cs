using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Library.Data;
using Web_Library.Models;

namespace Web_Library.Controllers
{
    public class BooksController : Controller
    {
        private LibraryDbContext _dbContext;

        public BooksController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books = await _dbContext.Books
            .OrderBy(b => b.Title).ThenBy(b => b.Author).ToArrayAsync();

            return View(books);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            Book? book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);

            if (book == null)
            {
                return NotFound("Not found !");
            }

            return View(book);

        }
    }
}
