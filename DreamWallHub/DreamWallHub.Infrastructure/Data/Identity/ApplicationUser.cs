using Microsoft.AspNetCore.Identity;

namespace DreamWallHub.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public byte[]? profilePicture { get; set; }
    }
}
