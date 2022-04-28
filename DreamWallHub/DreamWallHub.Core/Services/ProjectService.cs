using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using DreamWallHub.Infrastructure.Data.Identity;
using DreamWallHub.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DreamWallHub.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IApplicationDbRepository repo;
     
        private readonly ApplicationDbContext db;

        public ProjectService(IApplicationDbRepository repo, ApplicationDbContext db)
        {
            this.repo = repo;
            this.db = db;
        }


        public async Task<bool> CreateProject(ProjectCreateViewModel model)
        {
            if (await ProjectAlreadyExistInCollection(model.ProjectName))
            {
                return false;
            }

            var user = db.Users.FirstOrDefault(x => x.Id == model.CreatorId);

            var project = new Project
            {
                ProjectName = model.ProjectName,
                ClientName = model.ClientName,
                Country = model.Country,  
                Description = model.Description,
                DesignPictureUrl = model.DesignPictureUrl,
                Id = model.Id,
                Materials = model.Materials,
                CreatorName = $"{user.FirstName} {user.LastName}",
                DateOfCreation = DateTime.Now.ToString(),
            };

            await repo.AddAsync(project);
            await repo.SaveChangesAsync();

            return true;
        }

        public async Task<Project> GetProjectById(string id)
        {
            return await repo.GetByIdAsync<Project>(id);
        }

        public Task<ProjectEditViewModel> GetProjectForEdit(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllProjectViewModel>> GetProjects()
        {
            var projects = repo.All<Project>();

            var projectView = await projects.Select(project => new AllProjectViewModel()
            {
                Id = project.Id,
                ClientName= project.ClientName,
                Country = project.Country,
                CreatorName = project.CreatorName,
                DateOfCreation= project.DateOfCreation,
                Description = project.Description,
                DesignPictureUrl= project.DesignPictureUrl,
                ProjectName = project.ProjectName,
            })
                .OrderByDescending(project => project.Id)
                .ToListAsync();

            return projectView;
        }

        public Task<bool> UpdateProject(ProjectEditViewModel model)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> ProjectAlreadyExistInCollection(string projectName)
        {
            var anime = await db.Projects.FirstOrDefaultAsync(x => x.ProjectName == projectName);

            if (anime == null)
            {
                return false;
            }

            return true;
        }
    }
}
