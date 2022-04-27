using DreamWallHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class ProjectEditViewModel
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Country { get; set; }
        public string? DesignPictureUrl { get; set; }
        public string Description { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
