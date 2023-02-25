using AutoMapper;
using System;
using SweetShop.Data;
using System.Threading.Tasks;
using SweetShop.ViewModels;
using System.Collections.Generic;
using SweetShop.Models;
using System.Linq;

namespace SweetShop.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateAsync(ProductFormServiceModel product)
        {
            var productToCreate = this.Mapper.Map<Product>(product);
            productToCreate.CreatedOn = DateTime.UtcNow;

            var allergens = new List<ProductAllergen>();

            foreach (var allergenId in product.AllergensIds.Distinct())
            {
                var productAllergen = new ProductAllergen()
                {
                    AllergenId = allergenId,
                    ProductId = productToCreate.Id,
                    CreatedOn = DateTime.UtcNow
                };
                allergens.Add(productAllergen);
            }
            productToCreate.ProductAllergen = allergens;

            await this.DbContext.Products.AddAsync(productToCreate);
            await this.DbContext.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllAllergensViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<TEntity>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductFormServiceModel product)
        {
            throw new NotImplementedException();
        }
    }
}
