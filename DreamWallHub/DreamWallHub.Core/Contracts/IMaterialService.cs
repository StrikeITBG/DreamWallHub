using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.Contracts
{
    public interface IMaterialService
    {
        Task<bool> AddMaterials(MaterialViewModel model);

        Task<bool> UpdateMaterials(Material model);

        Task<Material> EditMaterials(string id);

        Task<IEnumerable<Material>> GetMaterials();

    }
}
