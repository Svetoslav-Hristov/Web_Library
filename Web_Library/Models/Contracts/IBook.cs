using System.ComponentModel.DataAnnotations;
using Web_Library.Models.Enums;

namespace Web_Library.Models.Contracts
{
    public interface IBook
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
       
    }
}
