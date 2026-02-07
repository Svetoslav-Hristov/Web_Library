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

        public  IActionResult Index()
        {

            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }


        public async Task<IActionResult> EnterPreview()
        {

            IEnumerable<PreviewBookModel> bookCollection = await _dbContext.Books.AsNoTracking().
               Where(b => b.CoverImageUrl != null).OrderByDescending(b=>b.Id).Select(b => new PreviewBookModel()
               {

                   Id = b.Id,
                   CoverImageUrl = b.CoverImageUrl,
                   Title = b.Title

               }).Take(5).OrderBy(pm=>pm.Title).ToArrayAsync();


            return View(bookCollection);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
