using System.ComponentModel.DataAnnotations;
using Web_Library.Data.Models.Contracts;

namespace Web_Library.Data.Models
{
    using static Web_Library.GCommon.EntityValidations.Users;
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
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(EmailAddressMaxLength)]
        public string Email { get; set; } = null!;

        public bool IsBlocked { get; set; }

        public virtual ICollection<UserBook> UserBooks { get; set; } = new List<UserBook>();

    }
}
