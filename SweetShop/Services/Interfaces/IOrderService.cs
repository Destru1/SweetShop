using SweetShop.DTOs;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Order;
using SweetShop.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderIndexViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsOrderViewModel GetDetails(int id);

        IEnumerable<ProductIdNameViewModel> GetProducts();

        IEnumerable<ClientIndexViewModel> GetClients();

        Task CreateAsync(OrderDTO order);

        Task<bool> UpdateAsync(int id,OrderDTO order);

        Task<bool> DeleteAsync(int id);
    }
}
