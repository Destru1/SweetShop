using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Product;

namespace SweetShop.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


        public IEnumerable<DetailProductViewModel> GetAll()

          => DbContext.Products.ProjectTo<DetailProductViewModel>(this.Mapper.ConfigurationProvider).ToList();



        public TEntity GetById<TEntity>(int id)
        {
            var product = this.DbContext.Products.Find(id);

            if (product == null)
            {
                throw new Exception("This product does not exist.");
            }

            var productToReturn = this.Mapper.Map<TEntity>(product);

            return productToReturn;
        }



        public async Task CreateAsync(ProductDTO product)
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
                    CreatedOn = DateTime.UtcNow,
                };
                allergens.Add(productAllergen);
            }
            productToCreate.ProductAllergen = allergens;

            await this.DbContext.Products.AddAsync(productToCreate);
            await this.DbContext.SaveChangesAsync();
        }
      

        public async Task<bool> UpdateAsync(int id,ProductDTO product)
        {
            var productToUpdate = await this.DbContext.Products
                .Include(x => x.ProductAllergen)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productToUpdate == null)
            {
                return false;
            }

            var allergens = new List<ProductAllergen>();

            foreach (var allergenId in product.AllergensIds.Distinct())
            {

                var productAllergen = new ProductAllergen()
                {
                    AllergenId = allergenId,
                    ProductId = productToUpdate.Id,
                    CreatedOn = DateTime.UtcNow,
                };
                allergens.Add(productAllergen);
            }
            this.Mapper.Map(product,productToUpdate);

            productToUpdate.ProductAllergen = allergens;
            productToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(productToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;

        }

      
        

        public async Task<bool> DeleteAsync(int id)
        {
            var product = this.GetById<Product>(id);

            if (product == null)
            {
                return false;
            }

            product.IsDeleted= true;
            product.DeletedOn = DateTime.UtcNow;

            this.DbContext.Remove(product);

            await this.DbContext.SaveChangesAsync();

            return true;
        }
    }
}
