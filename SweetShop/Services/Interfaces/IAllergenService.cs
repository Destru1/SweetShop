using SweetShop.DTOs;
using SweetShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public interface IAllergenService
    {
        IEnumerable<AllAllergensViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsAlergenViewModel GetDetails(int id);

        Task CreateAsync(CreateAllergenDTO allergen);

        Task<bool> UpdateAsync(UpdateAllergenDTO allergen);

        Task<bool> DeleteAsync(int id);
    }
}
