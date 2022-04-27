using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data.Identity;

namespace DreamWallHub.Core.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<UserEditViewModel> GetUserForEdit(string id);

        Task<bool> UpdateUser(UserEditViewModel model);

        Task<ApplicationUser> GetUserById(string id);
    }
}
