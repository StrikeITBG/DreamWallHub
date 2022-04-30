using System.ComponentModel.DataAnnotations;

namespace DreamWallHub.Core.ViewModels
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
        [Display(Name = "UserName")]
        public string? UserName { get; set; }
    }
}
