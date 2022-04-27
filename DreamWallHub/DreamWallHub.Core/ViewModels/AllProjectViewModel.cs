using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class AllProjectViewModel
    {
        public string Id { get; set; } 
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Country { get; set; }
        public string CreatorName { get; set; }
        public string DateOfCreation { get; set; }
        public string? DesignPictureUrl { get; set; }
        public string Description { get; set; }
    }
}
