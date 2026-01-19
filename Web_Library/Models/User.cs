using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
using Web_Library.Models.Contracts;

namespace Web_Library.Models
{
    using static Models.Common.EntityValidations.User;
    public class User : IUser
    {


        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameUserMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameUserMaxLength)]
        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(EmailAddressMaxLength)]
        public string Email { get; set; } = null!;

        public bool IsBlocked { get; set; }

        public virtual ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();

    }
}
