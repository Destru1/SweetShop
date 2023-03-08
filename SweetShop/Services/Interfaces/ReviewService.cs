using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Product;
using SweetShop.ViewModels.Review;

namespace SweetShop.Services.Interfaces
{
    public class ReviewService : BaseService, IReviewService
    {
        public ReviewService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }



        public IEnumerable<IndexReviewViewModel> GetAll()
        {
            var reviews = this.DbContext.Reviews.ProjectTo<IndexReviewViewModel>(this.Mapper.ConfigurationProvider).ToList();

            return reviews;
        }

        public TEntity GetById<TEntity>(int id)
        {
            var review = this.DbContext.Reviews.Find(id);

            if (review == null)
            {
                //todo review does not exist
            }

            var reviewToReturn = this.Mapper.Map<TEntity>(review);

            return reviewToReturn;
        }

        public DetailsReviewViewModel GetDetails(int id)
        {
            var review = this.DbContext.Reviews.Where(x => x.Id == id)
                .Select(x => new DetailsReviewViewModel
                {
                    Id = x.Id,
                    Product = x.Product.Name,
                    Client = x.Client.FirstName + " " + x.Client.LastName,
                    Rating = x.Rating,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                })
                .FirstOrDefault();

            return review;

        }


        public IEnumerable<ClientIndexViewModel> GetClients()
        {
            IEnumerable<ClientIndexViewModel> clients = this.DbContext.Clients.Select(x => new ClientIndexViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                City = x.City,
            })
                .ToList();
            return clients;
        }


        public IEnumerable<ProductIdNameViewModel> GetProducts()
        {
            IEnumerable<ProductIdNameViewModel> products = this.DbContext.Products.Select(x => new ProductIdNameViewModel
            {
                Id = x.Id,
                Name = x.Name,
            })
                .ToList();

            return products;
        }


        public async Task CreateAsync(ReviewDTO review)
        {
            var reviewToCreate = new Review();

            reviewToCreate.Description = review.Description;
            reviewToCreate.Rating = review.Rating;
            reviewToCreate.ClientId = review.ClientId;
            reviewToCreate.ProductId = review.ProductId;
            reviewToCreate.CreatedOn = DateTime.UtcNow;

            await this.DbContext.AddAsync(reviewToCreate);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, ReviewDTO review)
        {
            var reviewToUpdate = this.DbContext.Reviews.Find(review.Id);

            if (review == null)
            {
                return false;
            }

            reviewToUpdate.Description = review.Description;
            reviewToUpdate.Rating = review.Rating;
            reviewToUpdate.ClientId = review.ClientId;
            reviewToUpdate.ProductId = review.ProductId;
            reviewToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(reviewToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = this.GetById<Review>(id);

            if (review == null)
            {
                return false;
            }

            this.DbContext.Remove(review);
            await this.DbContext.SaveChangesAsync();

            return true;
        }


    }
}
