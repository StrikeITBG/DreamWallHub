using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class RequestOfferViewModel
    {
        public string Id { get; set; }

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
        [Range(5, 15)]
        public int PhoneNumber { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
