using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
            IQueryable<RegisterModelView> usersRegister = _dbContext.UsersBooks.
              Where(ub => ub.Status == BookStatus.PickedUp || ub.Status == BookStatus.Reserved)
               .Select(ub => new RegisterModelView()
               {
                   LoanId = ub.Id,
                   UserId = ub.UserId,
                   UserFirstName = ub.User.FirstName,
                   UserLastName = ub.User.LastName,
                   BookId = ub.BookId,
                   BookTitle = ub.Book.Title,
                   PickUpDate = ub.PickUpDate,
                   ReturnDate = ub.ReturnDate,
                   ReservedOn = ub.ReservedOn,
                   ReservationExpiresOn = ub.ReservationExpiresOn,
                   Status = ub.Status
               }).OrderByDescending(ub => ub.PickUpDate.HasValue);


            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            await CheckingOverdueUsers(today, usersRegister);

            await CheckingMissReservation(today, usersRegister);


            if (search != null)
            {
                string criteria = search.Trim().ToLower();

                var foundRecords = await usersRegister.Where(ur => ur.UserFirstName.ToLower().Contains(criteria) ||
                ur.UserLastName.ToLower().Contains(criteria)).OrderBy(ur => ur.UserFirstName).ThenBy(ur => ur.UserLastName).ToArrayAsync();

                return View(foundRecords);

            }

            var currentRecords = await usersRegister.OrderBy(ur => ur.UserFirstName).ThenBy(ur => ur.UserLastName).ToArrayAsync();

            return View(currentRecords);

        }


        [HttpGet]

        public async Task<IActionResult> CreateLoan()
        {

            var users = await _dbContext.Users.AsNoTracking()
            .Select(u => new { Id = u.Id, UserName = $"{u.FirstName} {u.LastName}" }).ToListAsync();

            var books = await _dbContext.Books.AsNoTracking()
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

            UserBook? isTakenBook = await _dbContext.UsersBooks.AsNoTracking()
            .FirstOrDefaultAsync(ub => ub.BookId == foundBook.Id &&
            (ub.Status == BookStatus.Reserved || ub.Status == BookStatus.PickedUp || ub.Status == BookStatus.Expired));

            if (isTakenBook != null)
            {
                string status = isTakenBook.Status.ToString();

                TempData["NotAvailable"] = $"The book is currently {status}";

                return RedirectToAction(nameof(Register));

            }



            if (foundUser.IsBlocked)
            {

                TempData["IncorrectUser"] = "The user is temporarily unable to rent a book due to an unclear status!";

                return RedirectToAction(nameof(Register));
            }

            try
            {

                DateOnly loanDate = DateOnly.FromDateTime(DateTime.UtcNow);
                DateOnly returnDate = loanDate.AddDays(BorrowingExpiryPeriod);



                UserBook newLoan = new UserBook()
                {
                    Id = Guid.NewGuid(),
                    UserId = foundUser.Id,
                    BookId = foundBook.Id,
                    PickUpDate = loanDate,
                    ReturnDate = returnDate,
                    Status = BookStatus.PickedUp

                };

                await _dbContext.UsersBooks.AddAsync(newLoan);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "Unexpected error is occurred while register new loan! Please try again later.");

            }

            return RedirectToAction(nameof(Register));
        }

        [HttpGet]
        public async Task<IActionResult> CreateReservation(Guid bookId)
        {
            if (bookId == Guid.Empty)
            {
                return BadRequest();
            }


            Book? book = await _dbContext.Books.FindAsync(bookId);

            if (book == null)
            {
                return NotFound();
            }



            CreateReserveModel model = new CreateReserveModel()
            {
                BookId = bookId,
                BookTitle = book.Title,
            };


            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReserveModel model)
        {
            if (!ModelState.IsValid)
            {
               await RestoreReservationModel(model);

                ModelState.AddModelError(string.Empty, "Invalid user use the search engine and field correctly");

               return View("CreateReservation",model);

            }

            bool takenOrReserve = await _dbContext.UsersBooks.AsNoTracking().AnyAsync(ub => ub.BookId == model.BookId &&
            (ub.Status == BookStatus.Reserved || ub.Status == BookStatus.PickedUp));

            if (takenOrReserve)
            {

                return BadRequest("Book is not available.");

            }


            try
            {

                DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
                DateOnly expiriesPeriod = today.AddDays(ReservedExpiryPeriod);

                UserBook newReservation = new UserBook()
                {
                    Id = Guid.NewGuid(),
                    UserId = model.UserId,
                    BookId = model.BookId,
                    ReservedOn = today,
                    ReservationExpiresOn = expiriesPeriod


                };

                await _dbContext.AddAsync(newReservation);

                await _dbContext.SaveChangesAsync();

                string bookId = model.BookId.ToString();

                TempData["SuccessReservation"] = "You have successfully reserved the book you selected.";

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                ModelState.AddModelError(string.Empty, "Unexpected error is occurred while register new reservation! Please try again later.");

                return View("CreateReservation", model);

            }

            return RedirectToAction("Details", "Books", new { Id = model.BookId });


        }

        [HttpGet]
        public async Task<IActionResult> EditLoan(Guid Id)
        {

            if (Id == Guid.Empty)
            {
                return BadRequest();
            }


            UserBook? foundRecord = await _dbContext.UsersBooks.Include(ub => ub.Book).Include(ub => ub.User).FirstOrDefaultAsync(ub => ub.Id == Id);


            var usersList = await _dbContext.Users.OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                .Select(u => new { Id = u.Id, UserName = $"{u.FirstName} {u.LastName}" }).ToArrayAsync();

            var bookList = await _dbContext.Books.Select(b => new { Id = b.Id, Title = b.Title }).OrderBy(b => b.Title).ToArrayAsync();


            CreateLoanView editLoanModel = new CreateLoanView()
            {

                UserId = foundRecord.UserId,
                BookId = foundRecord.BookId,

                UsersList = usersList.Select(u => new SelectListItem()
                {

                    Text = u.UserName,
                    Value = u.Id.ToString()

                }),

                BookList = bookList.Select(b => new SelectListItem()
                {

                    Text = b.Title,
                    Value = b.Id.ToString()
                }),


            };

            return View(editLoanModel)
;
        }

        [HttpPost]
        public async Task<IActionResult> EditLoan([FromRoute] Guid Id, CreateLoanView model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (Id == Guid.Empty)
            {

                return NotFound();
            }


            var editRecord = await _dbContext.UsersBooks.FirstOrDefaultAsync(ub => ub.Id == Id);


            DateOnly pickUpDate = model.PickUpDate;

            DateOnly returnDate = pickUpDate.AddDays(BorrowingExpiryPeriod);

            try
            {
                editRecord.UserId = model.UserId;
                editRecord.BookId = model.BookId;
                editRecord.PickUpDate = pickUpDate;
                editRecord.ReturnDate = returnDate;
                editRecord.Status = BookStatus.PickedUp;
                await _dbContext.SaveChangesAsync();


            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                TempData["Unchanged"] = "An unexpected problem has occurred that prevents editing!";
            }

            TempData["ConfirmOrEdit"] = "You have successfully changed or created your Loan.";


            return RedirectToAction(nameof(Register))
;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLoan(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();
            }

            var removeLoan = await _dbContext.UsersBooks.FirstOrDefaultAsync(ub => ub.Id == Id);

            if (removeLoan == null)
            {
                return NotFound();
            }

           

            try
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);

                removeLoan.Status = BookStatus.Returned;
                removeLoan.ReturnDate = today;

                var anotherBook =await _dbContext.UsersBooks.AnyAsync(ub => ub.UserId == removeLoan.UserId &&
                ub.Id != removeLoan.Id && ub.Status == BookStatus.PickedUp);
                
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == removeLoan.UserId);

                if (user != null && user.IsBlocked)
                {
                    if (!anotherBook)
                    {
                        user.IsBlocked = false;
                    }
                }

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return StatusCode(500);

            }

            return RedirectToAction(nameof(Register))
;
        }

        public async Task<IActionResult> SearchByCriteria(CreateReserveModel model)
        {

            if (string.IsNullOrEmpty(model.SearchingCriteria))
            {
                ModelState.AddModelError("SearchingCriteria", "User with this email or phone number was not found!");

                return View("CreateReservation", model);
            }


            string criteria = model.SearchingCriteria.Trim().ToLower();

            var foundUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == criteria || u.PhoneNumber.ToLower() == criteria);

            if (foundUser == null)
            {
                ModelState.AddModelError("SearchingCriteria", "User with this email or phone number was not found!");

                return View("CreateReservation", model);

            }

            model.SearchingCriteria = criteria;
            model.UserId = foundUser.Id;
            model.UserName = $"{foundUser.FirstName} {foundUser.LastName}";


            ModelState.Clear();


            return View("CreateReservation", model);


        }

        private async Task CheckingOverdueUsers(DateOnly today, IQueryable<RegisterModelView> usersRegister)
        {

            var overdueUsers = await usersRegister.Where(ur => ur.ReturnDate.HasValue && ur.ReturnDate.Value < today &&
            ur.Status == BookStatus.PickedUp).Select(u => u.UserId).Distinct().ToListAsync();

            if (overdueUsers.Any())
            {

                var users = await _dbContext.Users.Where(u => overdueUsers.Contains(u.Id) && !u.IsBlocked).ToListAsync();


                foreach (User user in users)
                {
                    user.IsBlocked = true;

                }

                await _dbContext.SaveChangesAsync();
            }


        }

        private async Task CheckingMissReservation(DateOnly today, IQueryable<RegisterModelView> usersRegister)
        {
            var missingReservation = await usersRegister.Where(ur => ur.ReservationExpiresOn.HasValue && ur.ReservationExpiresOn.Value < today &&
            ur.Status == BookStatus.Reserved).Select(ur => ur.LoanId).Distinct().ToListAsync();

            if (missingReservation.Any())
            {

                var reservations = await _dbContext.UsersBooks.Where(u => missingReservation.Contains(u.Id)).ToListAsync();

                _dbContext.UsersBooks.RemoveRange(reservations);


                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task RestoreReservationModel(CreateReserveModel model)
        {
            var book = await _dbContext.Books.FindAsync(model.BookId);

            if (book != null)
            {
                model.BookId = book.Id;
                model.BookTitle = book.Title;
                
            }
        }


    }
}
