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

        public async Task<ProjectEditViewModel> GetProjectForEdit(string id)
        {
            var project = db.Projects.Where(x => x.Id == id).FirstOrDefault();

            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            var material = repo.All<Material>().Where(m => m.Project.Id == id).FirstOrDefault();

            var projextExist = new ProjectEditViewModel()
            {
                Id = id,
                ClientName = project.ClientName,
                Country = project.Country,
                Description = project.Description,
                MaterialId = material == null ? "" : material.Id,
                Materials = repo.All<Material>(),
                ProjectName = project.ProjectName,
                DesignPictureUrl = project.DesignPictureUrl,

            };

            return projextExist;

        }

        public async Task<IEnumerable<AllProjectViewModel>> GetProjects()
        {
            var projects = repo.All<Project>();

            var projectView = await projects.Select(project => new AllProjectViewModel()
            {
                Id = project.Id,
                ClientName = project.ClientName,
                Country = project.Country,
                CreatorName = project.CreatorName,
                DateOfCreation = project.DateOfCreation,
                Description = project.Description,
                DesignPictureUrl = project.DesignPictureUrl,
                ProjectName = project.ProjectName,
            })
                .OrderByDescending(project => project.Id)
                .ToListAsync();

            return projectView;
        }

        public async Task<bool> UpdateProject(ProjectEditViewModel model)
        {
            bool result = false;

            var project = await repo.GetByIdAsync<Project>(model.Id);

            if (project != null)
            {
              project.ProjectName = model.ProjectName;
                project.Description = model.Description;
                project.DesignPictureUrl = model.DesignPictureUrl;
                project.ClientName = model.ClientName;
                project.Country = model.Country;
                project.Id = model.Id;


                var materialToEdit = await repo.GetByIdAsync<Material>(model.MaterialId);
                if (materialToEdit != null)
                {
                    materialToEdit.Project = project;
                }


                // for model.Id (project id), select first material - select * from materials where projectId = model.Id limit 1
                // if there are no materials (above query returns empty set) - create record in materials table - insert into materials values(, model.Metal, model.Fastenrs)
                // else update first material - update existing Materils Entity with data from model(ProjectEditViewModel)


                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
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
