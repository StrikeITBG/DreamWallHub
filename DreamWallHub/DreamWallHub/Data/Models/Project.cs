using System;
using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Data.Models
{
    public class Project
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Creator { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public ICollection<Material> Materials { get; set; }

    }
}
