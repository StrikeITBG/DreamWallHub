using DreamWallHub.Core.Constants;
using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DreamWallHub.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(IProjectService projectService, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.projectService = projectService;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            var projects = await projectService.GetProjects();

            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProjects()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProjects(ProjectCreateViewModel model)
        {
            ClaimsPrincipal? userContext = httpContextAccessor.HttpContext?.User;
            ApplicationUser? user = await userManager.GetUserAsync(userContext);

            model.CreatorId = user.Id;

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            if (await projectService.CreateProject(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return RedirectToAction(nameof(ManageProjects));
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageProjects()
        {
            var projects = await projectService.GetProjects();

            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> EditProjects(string id)
        {
            var model = await projectService.GetProjectForEdit(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProjects(ProjectEditViewModel model)
        {

            if (await projectService.UpdateProject(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return RedirectToAction(nameof(ManageProjects));
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);
        }
    }
}
