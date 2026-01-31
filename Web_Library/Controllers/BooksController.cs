using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using Web_Library.Data;
using Web_Library.Models;
using Web_Library.Models.Enums;
using Web_Library.ViewModels.Book;
using static System.Net.Mime.MediaTypeNames;
namespace Web_Library.Controllers
{
    public class BooksController : Controller
    {
        private LibraryDbContext _dbContext;
        private IWebHostEnvironment _environment;

        public BooksController(LibraryDbContext dbContext, IWebHostEnvironment environment)
        {
            this._dbContext = dbContext;
            this._environment = environment;

        }


        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower().Trim();

                IEnumerable<Book> searchingBook = await _dbContext.Books.AsNoTracking().
                Where(b => b.Title.ToLower().Contains(search) || b.Author.ToLower().Contains(search)).ToArrayAsync();

                return View(searchingBook);
            }

            IEnumerable<Book> books = await _dbContext.Books.AsNoTracking()
            .OrderBy(b => b.Title).ThenBy(b => b.Author).ToArrayAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            Book? book = await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);

            if (book == null)
            {
                return NotFound("Not found !");
            }

            return View(book);

        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _dbContext.Books.AsNoTracking()
           .Select(b => b.Author).Distinct().ToListAsync();

            var genres = Enum.GetValues<Genre>();



            string coverPath = Path.Combine(_environment.WebRootPath, "images");


            var covers = Directory.GetFiles(coverPath).Select(f => Path.GetFileName(f))
                .Select(f => new SelectListItem
                {
                    Text = f,
                    Value = f
                });



            var model = new BookFormModel()
            {

                Authors = authors.Select(a => new SelectListItem()
                {
                    Text = a,
                    Value = a
                }),
                Genres = genres.Select(g => new SelectListItem()
                {
                    Text = g.ToString(),
                    Value = g.ToString()

                }),
                Covers = covers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookFormModel formModel)
        {
            if (!ModelState.IsValid)
            {

                return View(formModel);
            
            
            }

            string authorName = string.Empty;

            if (!string.IsNullOrWhiteSpace(formModel.SelectedAuthor))
            {
                authorName = formModel.SelectedAuthor;

            }
            else if (!string.IsNullOrWhiteSpace(formModel.NewAuthor))
            {
                authorName = formModel.NewAuthor;
            }
            else
            {
                ModelState.AddModelError("", "Please select or add an author.");

                return View(formModel);

            }

            Book newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = formModel.Title,
                Year = formModel.Year,
                CoverImageUrl = formModel.CoverImage,
                Description = formModel.Description,
                Author = authorName,
                Genre = formModel.Genre

            };

            await _dbContext.Books.AddAsync(newBook);

            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Book created successufully.";

            return RedirectToAction(nameof(Details), new {newBook.Id} );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {

            var authors = await _dbContext.Books.AsNoTracking()
           .Select(b => b.Author).Distinct().ToListAsync();

            var genres = Enum.GetValues<Genre>();
            string coverPath = Path.Combine(_environment.WebRootPath, "images");


            var covers = Directory.GetFiles(coverPath).Select(f => Path.GetFileName(f))
                .Select(f => new SelectListItem
                {
                    Text = f,
                    Value = f
                });


            Book? book = await _dbContext.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == Id);

            if (book == null)
            {
                return NotFound();
            }

            BookFormModel model = new BookFormModel()
            {
                Title = book.Title,
                Year = book.Year,
                Covers = covers,
                Description = book.Description,
                Authors = authors.Select(a => new SelectListItem()
                {
                    Text = a,
                    Value = a
                }),
                Genres = genres.Select(g => new SelectListItem()
                {
                    Text = g.ToString(),
                    Value = g.ToString()
                })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, BookFormModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);

            }

            var book = await _dbContext.Books.FindAsync(Id);

            if (book == null)
            {
                return NotFound();
            }

            book.Title = model.Title;
            book.Year = model.Year;
            book.CoverImageUrl = model.CoverImage ?? book.CoverImageUrl;
            book.Description = model.Description;
            book.Author = model.SelectedAuthor ?? book.Author;
            book.Genre = model.Genre;



            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { Id });
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var foundBook = await _dbContext.Books.FindAsync(Id);

            if (foundBook == null)
            {
                return NotFound();
            }


            var isTaken = await _dbContext.UsersBooks.AnyAsync(ub => ub.BookId == Id);

            if (isTaken)
            {
                TempData["Error"] = "Book cannot be deleted because it is currently taken.";
                return RedirectToAction(nameof(Details), new { Id });

            }

            _dbContext.Remove(foundBook);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






    }
}
