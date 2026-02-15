using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Library.Data.Models;
using Web_Library.Services.Core.Common;
using Web_Library.ViewModels.User;

namespace Web_Library.Services.Core.Interfaces
{
    public interface IUsersService
    {
        Task<ServiceResult<IEnumerable<User>>> GetAllUsersWithOrWithoutSearchCriteriaAsync(string? search);

        Task<ServiceResult<User>> ChangeUserStatusAsync(Guid Id);

        ServiceResult<UserFormModel> CreateNewUserUsingFormModel();

        Task<ServiceResult<UserFormModel>> ConfirmRegistrationNewUserAsync(UserFormModel model);

        Task<ServiceResult<UserFormModel>> EditUserRegistrationAsync(Guid Id);

        Task<ServiceResult<UserFormModel>> ConfirmEditChangesAsync(Guid Id,UserFormModel model);

        Task<ServiceResult<UserViewModel>> GetAllUserDetailsAsync(Guid Id);


        Task<ServiceResult<User>> DeleteUserProfileAsync(Guid Id);

    }
}
