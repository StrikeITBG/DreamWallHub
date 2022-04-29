using DreamWallHub.Core.Constants;
using DreamWallHub.Core.Contracts;
using DreamWallHub.Infrastructure.Data;
using DreamWallHub.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace DreamWallHub.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IReviewService reviewService;
        private readonly ICommentService commentService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentController(IReviewService reviewService,
            IHttpContextAccessor httpContextAccessor,
            ICommentService commentService,
            UserManager<ApplicationUser> userManager)
        {
            this.reviewService = reviewService;
            this.commentService = commentService;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewComments(string id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Review = await reviewService.GetReviewById(id);
            mymodel.Comments = await commentService.GetCommentsByReview(id);

            return View(mymodel);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewComments(Comment model)
        {
            ClaimsPrincipal? userContext = httpContextAccessor.HttpContext?.User;
            ApplicationUser? user = await userManager.GetUserAsync(userContext);

            model.UserId = user.Id;

            ViewBag.Description = model.Description;

            if (await commentService.AddCommentToReview(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Успешен запис!";
                return RedirectToAction(nameof(ReviewComments), new { model.ReviewId });
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return RedirectToAction(nameof(ReviewComments), new { model.ReviewId });
        }
    }
}
