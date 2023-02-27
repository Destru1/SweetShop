using AutoMapper;
using AutoMapper.QueryableExtensions;
using SweetShop.Data;
using SweetShop.Models;
using SweetShop.ViewModels;
using SweetShop.ViewModels.Product;
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

        public async Task CreateAsync(CreateAllergenBindingModel allergen)
        {
            var allergenToAdd = this.Mapper.Map<Allergen>(allergen);
            allergenToAdd.CreatedOn = DateTime.UtcNow;

            await this.DbContext.Allergens.AddAsync(allergenToAdd);
            await this.DbContext.SaveChangesAsync();
        }


        public TEntity GetById<TEntity>(int id)
        {
            var allergen = this.DbContext.Allergens.Find(id);

            if (allergen == null)
            {
                //TODO Error message
            }
            var allergenToReturn = this.Mapper.Map<TEntity>(allergen);

            return allergenToReturn;
        }


        public DetailsAlergenViewModel GetDetails(int id)
        {
            var allergen = this.DbContext.Allergens
                .Where(x => x.Id == id)
                .Select(a => new DetailsAlergenViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    CreatedOn= a.CreatedOn,
                    ModifiedOn = a.ModifiedOn,
                    Products = a.ProductAllergen
                    .Select(a => new ProductIdNameViewModel
                    {
                        Id = a.ProductId,
                        Name = a.Product.Name,
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return allergen;
        }



        public IEnumerable<AllAllergensViewModel> GetAll()
       => DbContext.Allergens.ProjectTo<AllAllergensViewModel>(this.Mapper.ConfigurationProvider).ToList();


        public async Task<bool> UpdateAsync(UpdateAllergenBindingModel allergen)
        {
            var allergenToUpdate = this.DbContext.Allergens.Find(allergen.Id);

            if (allergenToUpdate == null)
            {
                return false;
            }
            this.Mapper.Map(allergen, allergenToUpdate);

            allergenToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(allergenToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;

        }


        public async Task<bool> DeleteAsync(int id)
        {
            var allergen = this.GetById<Allergen>(id);

            if (allergen == null)
            {
                return false;
            }

            allergen.IsDeleted = true;
            allergen.DeletedOn = DateTime.UtcNow;

            this.DbContext.Remove(allergen);
            await this.DbContext.SaveChangesAsync();
            return true;
        }


    }
}
