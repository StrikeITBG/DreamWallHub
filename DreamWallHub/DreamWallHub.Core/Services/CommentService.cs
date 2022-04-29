using DreamWallHub.Core.Contracts;
using DreamWallHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DreamWallHub.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext db;

        public CommentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddCommentToReview(Comment model)
        {
            var review = await db.Reviews.Where(x => x.Id == model.ReviewId)
                 .FirstOrDefaultAsync();

            if (review == null)
            {
                return false;
            }
            try
            {
                Comment comment = new()
                {
                    ReviewId = model.ReviewId,
                    Description = model.Description,
                    Date = DateTime.Now.ToString(),
                    UserId = model.UserId
                };
                review.Comments.Add(comment);

                await db.Comments.AddAsync(comment);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            var comments = await db.Comments
                     .Include(x => x.User)
                     .Include(x => x.Review)
                     .ToListAsync();

            return comments;
        }

        public async Task<List<Comment>> GetCommentsByReview(string id)
        {
            var comments = await db.Comments
                .Include(x => x.User)
                .Where(x => x.ReviewId == id)
                .ToListAsync();

            return comments;
        }
    }

}
