using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Web_Library.Data;
using Web_Library.Models;
using Web_Library.ViewModels.User;

namespace Web_Library.Controllers
{
    public class UsersController : Controller
    {
        private LibraryDbContext _dbContext;

        public UsersController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {

            IQueryable<User> allUsers = _dbContext.Users.AsNoTracking()
            .OrderBy(u => u.FirstName).ThenBy(u => u.LastName).ThenBy(u=>u.Age);



            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower().Trim();

                bool isValidAge = int.TryParse(search, out int age);

                IEnumerable<User> foundUsers = await allUsers.AsNoTracking().Where(u => u.FirstName.ToLower().Contains(search) ||
                u.LastName.ToLower().Contains(search) ||(isValidAge && u.Age == age)).ToArrayAsync();

                if (!foundUsers.Any())
                {

                    TempData["NotFound"] = "User/s not found!";
                    
                    View(foundUsers);
                }

                return View(foundUsers);

            }


            IEnumerable<User> users = await allUsers.AsNoTracking().ToArrayAsync();

            if (!users.Any())
            {
                TempData["EmptyCollection"] = "There no added users in data base!";

                return RedirectToAction(nameof(Index));
            }

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();

            }


            User? blockedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (blockedUser == null)
            {

                return NotFound();
            }

            if (!blockedUser.IsBlocked)
            {
                TempData["NotNeed"] = "Тhe user is not blocked !";

                return RedirectToAction(nameof(Index));

            }

            try
            {

                blockedUser.IsBlocked = false;


                await _dbContext.SaveChangesAsync();

                TempData["SuccessStatus"] = "User status has been changed successfully.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                TempData["ErrorStatus"] = "Unexpected error is occurred while change status of this user! Please try again later.";


            }

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            UserFormModel model = new UserFormModel()
            {

            };


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var email = model.Email.Trim().ToLower();

            var invalidEmail = await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == email);

            if (invalidEmail)
            {
                ModelState.AddModelError("Email", "Email all ready exist in database ! ");

                return View(model);
            }


            try
            {
                User newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    IsBlocked = false

                };


                await _dbContext.AddAsync(newUser);

                await _dbContext.SaveChangesAsync();


            }
            catch (Exception m)
            {


                Console.WriteLine(m);
                ModelState.AddModelError(string.Empty, "Unexpected error is occurred while register user! Please try again later.");

                return View(model);


            }

            TempData["SuccessRegistration"] = "The user was successfully registered.";

            return RedirectToAction("Index", "Books");

        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var foundUser = await _dbContext.Users.Include(u => u.UserBooks).ThenInclude(ub => ub.Book)
                .AsNoTracking().FirstOrDefaultAsync(u => u.Id == Id);

            if (foundUser == null)
            {
                return NotFound();
            }

            UserViewModel model = new UserViewModel()
            {
                Id = foundUser.Id,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                Age = foundUser.Age,
                Address = foundUser.Address,
                PhoneNumber = foundUser.PhoneNumber,
                Email = foundUser.Email,
                IsBlocked = foundUser.IsBlocked,
                UserHistory = foundUser.UserBooks.Select(ub => new UserBookHistoryModel()
                {
                    BookId = ub.BookId,
                    Title = ub.Book.Title,
                    PickUpDate = ub.PickUpDate,
                    ReturnDate = ub.ReturnDate


                }).OrderByDescending(ub => ub.PickUpDate).ToArray()

            };



            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            if (Id == Guid.Empty)
            {

                return BadRequest();
            }


            User? user = await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == Id);

            if (user == null)
            {

                return NotFound();

            }

            UserFormModel formModel = new UserFormModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] Guid Id, UserFormModel formModel)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();

            }

            if (!ModelState.IsValid)
            {

                return View(formModel);
            }

            User? foundUser = await _dbContext.Users.FindAsync(Id);

            if (foundUser == null)
            {
                return NotFound();
            }

            bool isEmailExist = await _dbContext.Users.AnyAsync(u => u.Email == formModel.Email.ToLower() && u.Id != Id);

            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(formModel);
            }



            try
            {

                foundUser.FirstName = formModel.FirstName;
                foundUser.LastName = formModel.LastName;
                foundUser.Age = formModel.Age;
                foundUser.Address = formModel.Address;
                foundUser.PhoneNumber = formModel.PhoneNumber;
                foundUser.Email = formModel.Email;

                await _dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "New changes saved successfully";

            }
            catch (Exception e)
            {

                Console.WriteLine(e);

                ModelState.AddModelError(string.Empty, "Unexpected error is occured while editing user! Please try again later.");

                return View(formModel);

            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
            {

                return BadRequest();

            }


            User? removedUser = await _dbContext.Users.FindAsync(Id);

            if (removedUser == null)
            {
                return NotFound();
            }

            if (_dbContext.UsersBooks.Any(u => u.UserId == Id))
            {

                TempData["ErrorMessage"] = "The user cannot be deleted due to unspecified obligations !!";
                return RedirectToAction(nameof(Delete), new { Id });
            }

            _dbContext.Remove(removedUser);

            await _dbContext.SaveChangesAsync();



            return RedirectToAction(nameof(Index));

        }
    }
}
