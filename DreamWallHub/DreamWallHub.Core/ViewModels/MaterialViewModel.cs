using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.ViewModels
{
    public class MaterialViewModel
    {
        public string Id { get; set; }

        [Required]
        [Range(0, 100)]
        public double Metal { get; set; }

        [Required]
        [Range(0, 3000)]
        public double Plywood { get; set; }

        [Required]
        [Range(0, 2000)]
        public double Paint { get; set; }

        [Required]
        [Range(0, 10000)]
        public double Fasteners { get; set; }
    }
}
