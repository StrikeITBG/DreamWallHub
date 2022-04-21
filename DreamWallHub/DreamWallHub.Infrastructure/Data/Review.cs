using DreamWallHub.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamWallHub.Infrastructure.Data
{
    public class Review
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
