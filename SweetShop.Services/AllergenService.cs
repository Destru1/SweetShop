using AutoMapper;
using SweetShop.Data;
using SweetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public class AllergenService : BaseService, IAllergenService
    {
        public AllergenService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task CreateAsync(CreateAllergenBIndingModel allergen)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllAllergensViewModel> GetAll()
       => this.DbContext.Allergens.
    }
}
