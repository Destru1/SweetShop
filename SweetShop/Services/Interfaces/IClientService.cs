using SweetShop.DTOs;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientIndexViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailClientViewModel GetDetails(int id);

        Task CreateAsync(ClientDTO client);

        Task<bool> UpdateAsync(int id,ClientDTO client);

        Task<bool> DeleteAsync(int id);
    }
}
