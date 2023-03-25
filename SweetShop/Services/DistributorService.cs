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
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;

namespace SweetShop.Services
{
    public class DistributorService : BaseService, IDistributorService
    {

        public DistributorService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }


        public IEnumerable<DistributorIndexViewModel> GetAll()
        {
            var distributors = this.DbContext.Distributors.ProjectTo<DistributorIndexViewModel>(this.Mapper.ConfigurationProvider).ToList();

            return distributors;
        }

        public TEntity GetById<TEntity>(int id)
        {
            var distributor = this.DbContext.Distributors.Find(id);

            if (distributor == null)
            {
                throw new ArgumentException("Distributor does not exist.");
            }

            var distributorToReturn = this.Mapper.Map<TEntity>(distributor);

            return distributorToReturn;
        }

        public DetailsDistributorViewModel GetDetails(int id)
        {
            var distributor = this.DbContext.Distributors.Where(x => x.Id == id)
                .Select(a => new DetailsDistributorViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    City = a.City,
                    Address = a.Address,
                    PhoneNumber = a.PhoneNumber,
                    User = a.User.Email,
                    CreatedOn = a.CreatedOn,
                    ModifiedOn = a.ModifiedOn,
                    Clients = a.Clients
                    .Select(x => new ClientIndexViewModel
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return distributor;
        }

        public async Task CreateAsync(DistributorDTO distributor)
        {
            var distributorToCreate = new Distributor();

            distributorToCreate.Name = distributor.Name;
            distributorToCreate.City = distributor.City;
            distributorToCreate.Address = distributor.Address;
            distributorToCreate.PhoneNumber = distributor.PhoneNumber;
            distributorToCreate.UserId = distributor.UserId;
            distributorToCreate.CreatedOn = DateTime.UtcNow;

            await this.DbContext.Distributors.AddAsync(distributorToCreate);
            await this.DbContext.SaveChangesAsync();


        }

        public async Task<bool> UpdateAsync(int id, DistributorDTO distributor)
        {

            Distributor distributorToUpdate = this.DbContext.Distributors.Find(distributor.Id);
            if (distributor == null)
            {
                return false;

            }
            distributorToUpdate.Name = distributor.Name;
            distributorToUpdate.City = distributor.City;
            distributorToUpdate.Address = distributor.Address;
            distributorToUpdate.PhoneNumber = distributor.PhoneNumber;
            distributorToUpdate.UserId = distributor.UserId;
            distributorToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(distributorToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var distributor = this.GetById<Distributor>(id);

            if (distributor == null)
            {
                return false;
            }

            this.DbContext.Remove(distributor);
            await this.DbContext.SaveChangesAsync();

            return true;
        }


    }
}
