using AutoMapper;
using AutoMapper.QueryableExtensions;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                throw new ArgumentException("Review does not exist.");
            }

            var reviewToReturn = this.Mapper.Map<TEntity>(review);

            return reviewToReturn;
        }


        public async Task CreateAsync(ReviewDTO review)
        {
            var reviewToCreate = new Review();

            var product = this.DbContext.Products.FirstOrDefault(x => x.Id == review.ProductId);

            reviewToCreate.Description = review.Description;
            reviewToCreate.Rating = review.Rating;
            reviewToCreate.ClientId = review.ClientId;
            reviewToCreate.ProductId = review.ProductId;
            reviewToCreate.CreatedOn = DateTime.UtcNow;
            product.Rating += reviewToCreate.Rating;
            product.TimesRated++;

            await this.DbContext.AddAsync(reviewToCreate);
            await this.DbContext.SaveChangesAsync();
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
