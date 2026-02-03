using System.ComponentModel.DataAnnotations;
using Web_Library.Models.Enums;

namespace Web_Library.ViewModels.System
{
    public class RegisterModelView
    {
        public Guid UserId { get; set; }


        public string UserFirstName { get; set; } = null!;

        public string UserLastName { get; set; } = null!;

        public Guid BookId { get; set; }


        public string BookTitle { get; set; } = null!;


        public DateOnly? PickUpDate { get; set; }


        public DateOnly? ReturnDate { get; set; }

        public BookStatus Status { get; set; }

    }
}
