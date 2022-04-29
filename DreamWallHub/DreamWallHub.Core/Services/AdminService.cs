using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data.Identity;
using DreamWallHub.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DreamWallHub.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly IApplicationDbRepository repo;

        public AdminService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            return new UserEditViewModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>()
                .Select(u => new UserListViewModel()
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.UserId);

            if (user != null)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
