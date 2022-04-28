using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    public class AboutController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
