using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Library.Models.Contracts;
using Web_Library.Models.Enums;

namespace Web_Library.Models
{
    public class UserBook:IUserBook
    {

        [Key]
        public Guid Id { get; set; }

        public DateOnly? ReservedOn { get; set; }

        public DateOnly? ReservationExpiresOn { get; set; }

        public DateOnly? PickUpDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        public BookStatus Status { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; } = null!;

    }
}
