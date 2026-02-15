using System.ComponentModel.DataAnnotations;

namespace Web_Library.ViewModels.System
{
    using static GCommon.EntityValidations.Users;
    public class CreateReserveModel
    {
        [Required]
        public Guid BookId { get; set; }

       
        public string? BookTitle { get; set; }

       
        [StringLength(EmailAddressMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string? SearchingCriteria { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public string? UserName { get; set; }

        public DateOnly? ReservedOn { get; set; }

        public DateOnly? ReservationExpiresOn { get; set; }

    }
}
