using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Library.Data.Models;
using Web_Library.Services.Core.Common;
using Web_Library.ViewModels.System;

namespace Web_Library.Services.Core.Interfaces
{
    public interface ISystemsService
    {
        Task<IEnumerable<RegisterModelView>> AllUserWhoHaveActiveLoanOrReservationAsync(string? search);

        Task<CreateLoanView> CreateNewLoanAsync();

        Task<ServiceResult<UserBook>> ConfirmNewLoanAsync(CreateLoanView model);

        Task<ServiceResult<CreateReserveModel>> CreateNewReservationAsync(Guid bookId);

        Task<ServiceResult<CreateReserveModel>> ConfirmNewReservationAsync(CreateReserveModel model);

        Task<ServiceResult<CreateLoanView>> EditCurrentLoanModelAsync(int Id);

        Task<ServiceResult<CreateLoanView>> ConfirmEditLoanModelAsync(int Id,CreateLoanView model);

        Task<ServiceResult<UserBook>> DeleteLoanAsync(int Id);

        Task<ServiceResult<CreateReserveModel>> FindUserByCriteriaAsync(CreateReserveModel model);

        Task RestoreReservationModelAsync(CreateReserveModel model);

    }
        
}
