using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Data.Models
{
    public class Material
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public double Plywood { get; set; }

        [Required]
        public double Paint { get; set; }

        [Required]
        public int Fasteners { get; set; }

        [Required]
        public double WorkHoursToComplete { get; set; }

        [Required]
        public double MetalConstruction { get; set; }
    }
}
