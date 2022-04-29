using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Infrastructure.Data
{
    public class Material
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(0,100)]
        public double Metal { get; set; }
        
        [Required]
        [Range(0,3000)]
        public double Plywood { get; set; }
      
        [Required]
        [Range(0, 2000)]
        public double Paint { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Fasteners { get; set; }


        public Project? Project { get; set; }
    }
}
