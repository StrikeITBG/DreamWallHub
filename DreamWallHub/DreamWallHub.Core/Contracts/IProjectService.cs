using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<AllProjectViewModel>> GetProjects();

        Task<ProjectEditViewModel> GetProjectForEdit(string id);

        Task<bool> UpdateProject(ProjectEditViewModel model);

        Task<Project> GetProjectById(string id);

        Task<bool> CreateProject(ProjectCreateViewModel model);
    }
}
