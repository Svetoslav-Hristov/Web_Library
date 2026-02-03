using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Library.Data;
using Web_Library.Models;
using Web_Library.ViewModels;
using Web_Library.ViewModels.Book;

namespace Web_Library.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly ILogger<WelcomeController> _logger;

        private readonly LibraryDbContext _dbContext;
        public WelcomeController(ILogger<WelcomeController> logger,LibraryDbContext dbContext)
        {
            _logger = logger;
            this._dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<PreviewBookModel> bookCollection = await _dbContext.Books.AsNoTracking().
                Where(b => b.CoverImageUrl != null).Select(b => new PreviewBookModel()
                {

                    Id = b.Id,
                    CoverImageUrl = b.CoverImageUrl,
                    Title = b.Title

                }).ToArrayAsync();

            IEnumerable<PreviewBookModel> lastBooks = bookCollection.TakeLast(5).OrderBy(b => b.Title).ToArray();
           
            return View(lastBooks);
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
