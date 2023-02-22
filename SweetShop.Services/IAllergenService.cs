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

        Task CreateAsync(CreateAllergenBIndingModel allergen);
    }
}
