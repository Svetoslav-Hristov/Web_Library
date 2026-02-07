using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Web_Library.ViewModels.Book
{
    public class PreviewBookModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        
        public string? CoverImageUrl { get; set; } = null!;

        
    }

}
