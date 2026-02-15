using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Library.ViewModels.Book;

namespace Web_Library.Services.Core.Interfaces
{
    public interface IWelcomeService
    {
        Task <IEnumerable<PreviewBookModel>> GetLatestTitlesPreviewAsync();
    }
}
