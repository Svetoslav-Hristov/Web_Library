using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Library.Data;
using Web_Library.Models;
using Web_Library.Models.Enums;
using Web_Library.ViewModels.System;

namespace Web_Library.Controllers
{
    using static Common.EntityValidations.UserBook;
    public class SystemsController : Controller
    {
        private readonly LibraryDbContext _dbContext;

        public SystemsController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Register(string? search)
        {
            IEnumerable<RegisterModelView> usersRegister = await _dbContext.UsersBooks.Include(ub => ub.Book).Include(ub => ub.User).
              Where(ub => ub.Status == BookStatus.PickedUp)
               .Select(ub => new RegisterModelView()
               {
                   UserId = ub.UserId,
                   UserFirstName = ub.User.FirstName,
                   UserLastName = ub.User.LastName,
                   BookId = ub.BookId,
                   BookTitle = ub.Book.Title,
                   PickUpDate = ub.PickUpDate,
                   ReturnDate = ub.ReturnDate,
                   Status = ub.Status
               }).OrderByDescending(ub => ub.PickUpDate.HasValue).ToArrayAsync();


            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var overdueUsers = usersRegister.Where(ur => ur.ReturnDate.HasValue && ur.ReturnDate.Value < today &&
            ur.Status == BookStatus.PickedUp).Select(u => u.UserId).Distinct().ToList();

            if (overdueUsers.Any())
            {

                var users = await _dbContext.Users.Where(u => overdueUsers.Contains(u.Id) && !u.IsBlocked).ToListAsync();


                foreach (User user in users)
                {
                    user.IsBlocked = true;

                }

                await _dbContext.SaveChangesAsync();
            }


            if (search != null)
            {
                string criteria = search.Trim().ToLower();

                var foundRecords = usersRegister.Where(ur => ur.UserFirstName.ToLower().Contains(criteria) ||
                ur.UserLastName.ToLower().Contains(criteria)).OrderBy(ur => ur.UserFirstName).ThenBy(ur => ur.UserLastName).ToArray();

                return View(foundRecords);

            }

            var curentRecords = usersRegister.OrderBy(ur => ur.UserFirstName).ThenBy(ur => ur.UserLastName).ToArray();




            return View(usersRegister);

        }


        [HttpGet]

        public async Task<IActionResult> CreateLoan()
        {

            var users = await _dbContext.Users
            .Select(u => new { Id = u.Id, UserName = $"{u.FirstName} {u.LastName}" }).ToListAsync();

            var books = await _dbContext.Books
            .Select(b => new { Id = b.Id, BookTitle = b.Title }).ToListAsync();



            CreateLoanView model = new CreateLoanView()
            {
                UsersList = users.Select(u => new SelectListItem()
                {

                    Text = u.UserName.ToString(),
                    Value = u.Id.ToString()

                }),
                BookList = books.Select(b => new SelectListItem()
                {

                    Text = b.BookTitle.ToString(),
                    Value = b.Id.ToString()

                })
            };

            return View(model);
        }



        [HttpPost]

        public async Task<IActionResult> CreateLoan(CreateLoanView model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();

            }


            User? foundUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == model.UserId);

            Book? foundBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == model.BookId);

            if (foundBook == null || foundUser == null)
            {

                return NotFound();
            }

            UserBook? isTakenBook = _dbContext.UsersBooks.AsNoTracking()
            .FirstOrDefault(ub => ub.BookId == foundBook.Id &&
            (ub.Status == BookStatus.Reserved || ub.Status == BookStatus.PickedUp || ub.Status == BookStatus.Expired));

            if (isTakenBook != null)
            {
                string status = isTakenBook.Status.ToString();

                TempData["NotAvilable"] = $"The book is currently {status}";

                return RedirectToAction(nameof(Register));

            }

            if (!foundUser.IsBlocked)
            {

                TempData["IncorectUser"] = "The user is temporarily unable to rent a book due to an unclear status!";

                return RedirectToAction(nameof(Register));
            }

            try
            {
                DateOnly loanDate = DateOnly.FromDateTime(DateTime.Now);

                DateOnly returnDate = loanDate.AddDays(BorrowingExpiryPeriod);



                UserBook newLoan = new UserBook()
                {

                    UserId = foundUser.Id,
                    BookId = foundBook.Id,
                    PickUpDate = loanDate,
                    ReturnDate = returnDate,
                    Status = BookStatus.PickedUp

                };

                await _dbContext.UsersBooks.AddAsync(newLoan);

                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "Unexpected error is occured while register new loan! Please try again later.");

            }

            return RedirectToAction(nameof(Register));
        }


        [HttpGet]
        public async Task<IActionResult> EditLoan()
        {


            return View()
;        }

        [HttpPost]
        public async Task<IActionResult> EditLoan(string input)
        {


            return View()
;
        }

        public async Task<IActionResult> DeleteLoan()
        {


            return View()
;
        }

    }
}
