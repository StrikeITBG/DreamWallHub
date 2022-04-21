using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Infrastructure.Data
{
    public class Project
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(60)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(60)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(60)]
        public string Country { get; set; }

        [Required]
        [StringLength(60)]
        public string CreatorName { get; set; }

        [Required]
        [StringLength(60)]
        public string DateOfCreation { get; set; }

        public string? DesignPictureUrl { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public ICollection<Material> Materials { get; set; } = new List<Material>();


    }
}
