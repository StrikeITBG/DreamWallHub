using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    public class MaterialsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
