using SweetShop.DTOs;
using SweetShop.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public interface IProductService
    {
        IEnumerable<ProductIndexViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        ProductRatingViewModel GetRating(int id);

        DetailProductViewModel GetDetails(int id);

        Task CreateAsync(ProductDTO product);

        Task<bool> UpdateAsync(int id, ProductDTO product);

        Task<bool> DeleteAsync(int id);
    }
}
