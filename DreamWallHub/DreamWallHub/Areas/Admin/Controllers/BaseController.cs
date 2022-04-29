using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DreamWallHub.Core.Constants;

namespace DreamWallHub.Areas.Admin.Controllers
{
    //[Authorize]
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {

    }
}
