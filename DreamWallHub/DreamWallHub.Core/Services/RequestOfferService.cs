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
    public class RequestOfferService : IRequestOfferService
    {
        private readonly IApplicationDbRepository repo;

        private readonly ApplicationDbContext db;

        public RequestOfferService(IApplicationDbRepository repo, ApplicationDbContext db)
        {
            this.repo = repo;
            this.db = db;
        }


        public async Task<bool> CreateRequest(RequestOfferViewModel model)
        {
           var newRequest = new RequestOffer
           {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Country = model.Country,
               Email = model.Email,
               Description = model.Description,
               PhoneNumber = model.PhoneNumber,
           };

            await repo.AddAsync(newRequest);
            await repo.SaveChangesAsync();

            return true;
        }

        public Task<RequestOfferViewModel> GetForEditRequestOffers(string id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> GetForUpdateRequestOffers(RequestOfferViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestOfferViewModel>> GetOffers()
        {
            throw new NotImplementedException();
        }
    }
}
