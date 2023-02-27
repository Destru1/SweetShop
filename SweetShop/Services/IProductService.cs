using SweetShop.Models;
using SweetShop.ViewModels.Product;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public interface IProductService
    {

        IEnumerable<DetailProductViewModel> GetAll();
        TEntity GetById<TEntity>(int id);

        Task CreateAsync(ProductFormServiceModel product);
        Task<bool> UpdateAsync(int id, ProductFormServiceModel product);

        Task<bool> DeleteAsync(int id);
    }
}
