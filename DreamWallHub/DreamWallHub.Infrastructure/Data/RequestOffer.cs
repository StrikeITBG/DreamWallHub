using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Infrastructure.Data
{
    public class RequestOffer
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Range(5,15)]
        public int PhoneNumber { get; set; }

       
        [StringLength(1000)]
        public string? Description { get; set; }

    }
}
