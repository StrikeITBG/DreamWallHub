using DreamWallHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class ProjectCreateViewModel
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
        public string CreatorId { get; set; }

        public string? DesignPictureUrl { get; set; }

       
        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
