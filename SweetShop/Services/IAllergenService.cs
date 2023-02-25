using SweetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public interface IAllergenService
    {
        IEnumerable<AllAllergensViewModel> GetAll();

        TEntity GetById<TEntity>(int id);

        DetailsAlergenViewModel GetDetails(int id);

        Task CreateAsync(CreateAllergenBindingModel allergen);

        Task<bool> UpdateAsync(UpdateAllergenBindingModel allergen);

        Task<bool> DeleteAsync(int id);
    }
}
