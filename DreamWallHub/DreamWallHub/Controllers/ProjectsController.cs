using DreamWallHub.Core.Constants;
using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using DreamWallHub.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace DreamWallHub.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService projectService;
        private readonly IReviewService reviewService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(IProjectService projectService, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IReviewService reviewService = null)
        {
            this.projectService = projectService;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> AllProjects()
        {
            var projects = await projectService.GetProjects();

            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Project(string id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Project = await projectService.GetProjectById(id);
            mymodel.Reviews = await reviewService.GetReviewsByProjectId(id);

            return View(mymodel);
        }

        [HttpPost]
        public async Task<IActionResult> Project(Review model)
        {
            ClaimsPrincipal? userContext = httpContextAccessor.HttpContext?.User;
            ApplicationUser? user = await userManager.GetUserAsync(userContext);

            model.CreatorId = user.Id;

            ViewBag.Description = model.Description;

            if (await reviewService.AddReviewToProject(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return RedirectToAction(nameof(Project), new { model.ProjectId });
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return RedirectToAction(nameof(Project), new { model.ProjectId });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> CreateProjects()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ManageProjects()
        {
            var projects = await projectService.GetProjects();

            return View(projects);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditProjects(string id)
        {
            var model = await projectService.GetProjectForEdit(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
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
