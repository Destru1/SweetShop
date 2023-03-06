﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;

namespace SweetShop.Services
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }



        public IEnumerable<ClientIndexViewModel> GetAll()
        {
            var clients = this.DbContext.Clients.ProjectTo<ClientIndexViewModel>(this.Mapper.ConfigurationProvider).ToList();

            return clients;
        }


        public TEntity GetById<TEntity>(int id)
        {
            var client = this.DbContext.Clients.Find(id);

            if (client == null)
            {
                //TODO client does not exist
            }

            var clientToReturn = this.Mapper.Map<TEntity>(client);

            return clientToReturn;
        }

        public IEnumerable<UserViewModel> GetUser()
        {
            IEnumerable<UserViewModel> users = this.DbContext.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                RoleName = x.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()
            }).ToList();

            return users;
        }

        public IEnumerable<DistributorIndexViewModel> GetDistributors()
        {
            IEnumerable<DistributorIndexViewModel> distributors = this.DbContext.Distributors
                .Select(x => new DistributorIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToList();

            return distributors;
        }
        public DetailClientViewModel GetDetails(int id)
        {
            var client = this.DbContext.Clients.Where(x => x.Id == id)
                .Select(a => new DetailClientViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    City = a.City,
                    Address = a.Address,
                    PhoneNumber = a.PhoneNumber,
                    PersonEntity= a.PersonEntity,
                    UserId = a.User.Email,
                    DistributorId = a.Distributor.Name,
                    CreatedOn = a.CreatedOn,
                    ModifiedOn = a.ModifiedOn,
                })

                .FirstOrDefault();

            return client;
        }



        public async Task CreateAsync(ClientDTO client)
        {
            var clientToCreate = new Client();

            clientToCreate.FirstName = client.FirstName;
            clientToCreate.LastName = client.LastName;
            clientToCreate.City = client.City;
            clientToCreate.Address = client.Address;
            clientToCreate.PhoneNumber = client.PhoneNumber;
            clientToCreate.PersonEntity= client.PersonEntity;
            clientToCreate.UserId = client.UserId;
            clientToCreate.DistributorId = client.DistributorId;
            clientToCreate.CreatedOn = DateTime.UtcNow;

            await this.DbContext.Clients.AddAsync(clientToCreate);
            await this.DbContext.SaveChangesAsync();
        }


        public async Task<bool> UpdateAsync(int id, ClientDTO client)
        {
            Client clientToUpdate = this.DbContext.Clients.Find(client.Id);

            if (client == null)
            {
                return false;
            }

            clientToUpdate.FirstName = client.FirstName;
            clientToUpdate.LastName = client.LastName;
            clientToUpdate.City = client.City;
            clientToUpdate.Address = client.Address;
            clientToUpdate.PhoneNumber = client.PhoneNumber;
            clientToUpdate.PersonEntity = client.PersonEntity;
            clientToUpdate.UserId = client.UserId;
            clientToUpdate.DistributorId = client.DistributorId;
            clientToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(clientToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = this.GetById<Client>(id);

            if (client == null)
            {
                return false;
            }

            this.DbContext.Remove(client);
            await this.DbContext.SaveChangesAsync();

            return true;
        }


    }
}
