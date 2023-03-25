using SweetShop.DTOs;
using SweetShop.ViewModels.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<IndexReviewViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        Task CreateAsync(ReviewDTO review);

        Task<bool> DeleteAsync(int id);


    }
}
