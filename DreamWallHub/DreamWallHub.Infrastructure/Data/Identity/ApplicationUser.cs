using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public byte[]? profilePicture { get; set; }
    }
}
