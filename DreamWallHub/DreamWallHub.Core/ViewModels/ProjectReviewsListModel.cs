using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class ProjectReviewsListModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Date { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Description { get; set; }
   
        public int CommentsCount { get; set; }
    }
}
