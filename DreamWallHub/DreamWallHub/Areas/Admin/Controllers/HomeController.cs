﻿using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
