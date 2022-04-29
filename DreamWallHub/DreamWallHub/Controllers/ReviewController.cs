using DreamWallHub.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamWallHub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> ManageReviews()
        {
            var reviews = await reviewService.GetReviews();

            return View(reviews);
        }
    }
}
