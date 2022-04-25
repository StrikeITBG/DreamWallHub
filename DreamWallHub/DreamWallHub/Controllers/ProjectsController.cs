using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController()
        {

        }
        public async Task<IActionResult> Projects()
        {
            return View();
        }

    }
}
