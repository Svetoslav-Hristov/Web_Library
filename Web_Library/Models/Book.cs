using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_Library.Models.Contracts;
using Web_Library.Models.Enums;


namespace Web_Library.Models
{
    using static Web_Library.Common.EntityValidations.Book;
    public class Book : IBook
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public int Year { get; set; }

        [MaxLength(URLMaxLength)]
        public string? CoverImageUrl { get; set; }

        [MaxLength(DescriptionMaxLenght)]
        public string? Description { get; set; }
        
        [Required]
        [MaxLength(AuthorMaxLengthName)]
        public string Author { get; set; } = null!;

        public Genre Genre { get; set; }

        public ICollection<UserBook> BookUsers { get; set; } = new List<UserBook>();
    }
}
