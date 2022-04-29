using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext db;

        public ReviewService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<bool> AddReviewToProject(Review model)
        {
            if (model==null)
            {
                return false;
            }
            var project = await db.Projects.Where(x => x.Id == model.ProjectId)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync();

            Review review = new()
            {
                ProjectId = project.Id,
                Description = model.Description,
                Date = DateTime.Now.ToString(),
                CreatorId = model.CreatorId
            };
            project.Reviews.Add(review);

            await db.Reviews.AddAsync(review);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Review> GetReviewById(string id)
        {
            try
            {
                var review = await db.Reviews
                .Include(x => x.Comments)
                .Include(x => x.Creator)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

                return review;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            var reviews = await db.Reviews
                  .Include(x => x.Comments)
                  .Include(x => x.Project)
                  .Include(x => x.Creator)
                  .ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<ProjectReviewsListModel>> GetReviewsByProjectId(string id)
        {
            var reviews = await db.Reviews
                .Include(x => x.Creator)
                .Where(x => x.ProjectId == id)
                .Select(x => new ProjectReviewsListModel
                {
                    Id = x.Id,
                    UserName = x.Creator.UserName,
                    Date = x.Date,
                    Description = x.Description,   
                    CommentsCount = x.Comments.Count
                }).ToListAsync();

            return reviews;
        }
    }
}
