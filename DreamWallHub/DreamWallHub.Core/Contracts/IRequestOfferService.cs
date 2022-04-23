using DreamWallHub.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWallHub.Core.Contracts
{
    public interface IRequestOfferService
    {
        Task<IEnumerable<RequestOfferViewModel>> GetOffers();

        Task<RequestOfferViewModel> GetForEditRequestOffers(string id);

        Task<bool> GetForUpdateRequestOffers(RequestOfferViewModel model);

        Task<bool> CreateRequest(RequestOfferViewModel model);



    }
}
