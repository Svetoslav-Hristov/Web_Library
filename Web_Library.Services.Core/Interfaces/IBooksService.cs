using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Library.Data;
using Web_Library.Data.Models;
using Web_Library.GCommon.Enums;
using Web_Library.Services.Core.Common;
using Web_Library.ViewModels.Book;

namespace Web_Library.Services.Core.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<FullPreviewModelBook>> GetAllBooksOrderedByTitleThanByAuthorAscAsync(string? search, Genre? genre);

        Task<FullPreviewModelBook> GetCurrentModelAsync(Guid Id);


        Task<ServiceResult< BookFormModel>> GetEmptyModelBookFormWithLoadedTypesAsync();

        Task <ServiceResult<Book>> CreateNewBookUsingBookFormModelAsync(BookFormModel model);

        Task<ServiceResult<BookFormModel>> EditBookUsingBookFormModelAsync(Guid Id);

        Task<ServiceResult<Book>> ConfirmEditChangesUsingBookFormModelAsync(Guid Id, BookFormModel model);

        Task<ServiceResult<bool>> DeleteCurrentBookAsync(Guid Id);

        Task BookModelDataFillingAsync(BookFormModel model);


    }
}
