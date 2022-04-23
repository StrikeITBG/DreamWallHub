using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    public class RequestOfferController : BaseController
    {
        private readonly IRequestOfferService requestOfferService;

        public RequestOfferController(IRequestOfferService requestOfferService)
        {
            this.requestOfferService = requestOfferService;
        }

        public object MessageConstants { get; private set; }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestOfferViewModel model)
        {
     
            if (await requestOfferService.CreateRequest(model))
            {
                return RedirectToAction("Index", "Home");            
            }

            return View(model);
        }

    }
}
