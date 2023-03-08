using SweetShop.DTOs;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Product;
using SweetShop.ViewModels.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<IndexReviewViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsReviewViewModel GetDetails(int id);

        IEnumerable<ProductIdNameViewModel> GetProducts();

        IEnumerable<ClientIndexViewModel> GetClients();

        Task CreateAsync(ReviewDTO review);

        Task<bool> UpdateAsync(int id, ReviewDTO review);

        Task<bool> DeleteAsync (int id);


    }
}
