using DreamWallHub.Infrastructure.Data;

namespace DreamWallHub.Core.Contracts
{
    public interface ICommentService
    {
        Task<bool> AddCommentToReview(Comment model);

        Task<IEnumerable<Comment>> GetComments();

        Task<List<Comment>> GetCommentsByReview(string id);
    }
}
