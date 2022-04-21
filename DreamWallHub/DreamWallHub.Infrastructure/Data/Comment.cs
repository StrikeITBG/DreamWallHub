using DreamWallHub.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamWallHub.Infrastructure.Data
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

    }
}
