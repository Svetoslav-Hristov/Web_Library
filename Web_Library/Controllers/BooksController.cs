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
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        public async Task<IActionResult> Index(string? search, Genre? genre)
        {
            IQueryable<FullPreviewModelBook> allBooks = _dbContext.Books.AsNoTracking().Select(b => new FullPreviewModelBook()
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = b.Author,
                YearOfPublished = b.Year,
                Genre = b.Genre,
                CoverImageUrl = b.CoverImageUrl

            }).OrderBy(b => b.Title).ThenBy(b => b.AuthorName);


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower().Trim();

                allBooks = allBooks.Where(b => b.Title.ToLower().Contains(search)
                 || b.AuthorName.ToLower().Contains(search));


            }

            if (genre != null)
            {
                allBooks = allBooks.Where(b => b.Genre == genre);

            }



            IEnumerable<FullPreviewModelBook> books = await allBooks.ToArrayAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {


            Book? book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == Id);


            if (book == null)
            {
                return NotFound("Not found !");
            }


            var bookStatus = await _dbContext.UsersBooks.AsNoTracking().FirstOrDefaultAsync(ub => ub.BookId == Id);

            BookStatus currentStatus;

            if (bookStatus != null)
            {
                currentStatus = bookStatus.Status;
            }
            else
            {
                currentStatus = BookStatus.Returned;
            }

            FullPreviewModelBook newBook = new FullPreviewModelBook()
            {
                Id = Id,
                Title = book.Title,
                YearOfPublished = book.Year,
                AuthorName = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                BookStatus = currentStatus,
                CoverImageUrl = book.CoverImageUrl
            };

            return View(newBook);

        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {

            BookFormModel model = new BookFormModel();

            await BookModelDataFillingAsync(model);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error ");

                return View(nameof(Create), formModel);


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
                ModelState.AddModelError(nameof(formModel.NewAuthor), "Or add an author.");

                ModelState.AddModelError(nameof(formModel.SelectedAuthor), "Please select and add an author.");

                await BookModelDataFillingAsync(formModel);

                return View(nameof(Create), formModel);

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

            try
            {

                await _dbContext.Books.AddAsync(newBook);

                await _dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Book created successfully.";

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "Unexpected error is occurred while added new book ! Please try again later.");

                return View("Create", formModel);
            }
            return RedirectToAction(nameof(Details), new { newBook.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {

            
            Book? book = await _dbContext.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == Id);

            if (book == null)
            {
                return NotFound();
            }

            BookFormModel model = new BookFormModel()
            {
                Title = book.Title,
                Year = book.Year,
                CoverImage = book.CoverImageUrl,
                Description = book.Description,
                SelectedAuthor = book.Author,
                Genre = book.Genre,

            };

            await BookModelDataFillingAsync(model);



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, BookFormModel model)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error");

                return View(nameof(Edit), model);

            }

            string authorName = string.Empty;

            if (!string.IsNullOrWhiteSpace(model.SelectedAuthor))
            {
                authorName = model.SelectedAuthor;

            }
            else if (!string.IsNullOrWhiteSpace(model.NewAuthor))
            {
                authorName = model.NewAuthor;
            }
            else
            {
                ModelState.AddModelError(nameof(model.SelectedAuthor), "Please select or add an author.");

                ModelState.AddModelError(nameof(model.NewAuthor), "Or add an author.");

                await BookModelDataFillingAsync(model);

                return View(nameof(Edit), model);

            }

            var book = await _dbContext.Books.FindAsync(Id);

            if (book == null)
            {
                return NotFound();
            }

            try
            {

                book.Title = model.Title;
                book.Year = model.Year;
                book.CoverImageUrl = model.CoverImage ?? book.CoverImageUrl;
                book.Description = model.Description;
                book.Author = authorName;
                book.Genre = model.Genre;

                await _dbContext.SaveChangesAsync();

                TempData["SuccessEdit"] = "You have successfully edited your book.";

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "Unexpected error is occurred! Please try again later.");

                return View("Edit", model);


            }





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

            try
            {

                _dbContext.Remove(foundBook);

                await _dbContext.SaveChangesAsync();

                TempData["SuccessDelete"] = "You have successfully deleted the book";

            }
            catch (Exception e)
            {

                Console.WriteLine(e);

                TempData["Error"] = "Unexpected error occurred! Please try again later.";

                return RedirectToAction(nameof(Details), new { Id = foundBook.Id });



            }
            return RedirectToAction(nameof(Index));
        }

        private async Task BookModelDataFillingAsync(BookFormModel model)
        {


            model.Authors = await _dbContext.Books.AsNoTracking().Select(b => b.Author).Distinct()
            .Select(a => new SelectListItem { Text = a, Value = a })
            .ToListAsync();

            model.Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>()
            .Select(g => new SelectListItem
            {
                Text = g.ToString(),
                Value = g.ToString()
            }).ToList();

            model.Covers = Directory.GetFiles(Path.Combine(_environment.WebRootPath, "images"))
                .Select(f => Path.GetFileName(f)).Select(f => new SelectListItem
                {
                    Text = f,
                    Value = f
                }).ToList();




        }




    }
}
