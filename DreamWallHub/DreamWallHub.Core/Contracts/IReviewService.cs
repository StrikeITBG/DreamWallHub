using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;

namespace DreamWallHub.Core.Contracts
{
    public interface IReviewService
    {
        Task<bool> AddReviewToProject(Review model);

        Task<IEnumerable<Review>> GetReviews();

        Task<Review> GetReviewById(string id);

        Task<IEnumerable<ProjectReviewsListModel>> GetReviewsByProjectId(string id);
    }
}
