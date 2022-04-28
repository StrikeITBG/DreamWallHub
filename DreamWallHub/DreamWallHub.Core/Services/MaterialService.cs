using DreamWallHub.Core.Contracts;
using DreamWallHub.Core.ViewModels;
using DreamWallHub.Infrastructure.Data;
using DreamWallHub.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.Services
{
    public class MaterialService : IMaterialService
    {
        public readonly ApplicationDbContext db;
        public readonly IApplicationDbRepository repo;

        public MaterialService(ApplicationDbContext db, IApplicationDbRepository repo)
        {
            this.db = db;
            this.repo = repo;
        }

        public async Task<bool> AddMaterials(MaterialViewModel model)
        {
            var material = new Material()
            {
                Fasteners = model.Fasteners,
                Metal = model.Metal,
                Paint = model.Paint,
                Plywood = model.Plywood,
            };

            await repo.AddAsync(material);
            await repo.SaveChangesAsync();

            return true;
        }

        public Task<Material> EditMaterials(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Material>> GetMaterials()
        {
            var materials = this.db.Materials.ToList();

            return materials;
        }

        public Task<bool> UpdateMaterials(Material model)
        {
            throw new NotImplementedException();
        }
    }
}
