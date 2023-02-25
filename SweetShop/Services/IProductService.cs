using SweetShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public interface IProductService
    {
        IEnumerable<AllAllergensViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        Task CreateAsync(ProductFormServiceModel product);

        Task<bool> UpdateAsync(ProductFormServiceModel product);

        Task<bool> DeleteAsync(int id);
    }
}
