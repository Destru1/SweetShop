using SweetShop.DTOs;
using SweetShop.ViewModels.Distributor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IDistributorService
    {
        IEnumerable<DistributorIndexViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsDistributorViewModel GetDetails(int id);

        Task CreateAsync(DistributorDTO distributor);

        Task<bool> UpdateAsync(int id, DistributorDTO distributor);

        Task<bool> DeleteAsync(int id);
    }
}
