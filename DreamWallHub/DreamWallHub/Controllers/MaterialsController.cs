using DreamWallHub.Core.Constants;
using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    public class MaterialsController : BaseController
    {
        private readonly IMaterialService materialService;
        private readonly UserManager<ApplicationUser> userManager;

        public IActionResult Index()
        {
            return View();
        }

        public MaterialsController(IMaterialService materialService, UserManager<ApplicationUser> userManager)
        {
            this.materialService = materialService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Materials()
        {
            var projects = await materialService.GetMaterials();

            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> AddMaterials()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMaterials(MaterialViewModel model)
        {
            if (await materialService.AddMaterials(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return Redirect("/Admin/Home/Index");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);
        }

    }
}
