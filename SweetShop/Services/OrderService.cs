using System;
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
using SweetShop.ViewModels.Order;
using SweetShop.ViewModels.Product;

namespace SweetShop.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(SweetShopDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


        public IEnumerable<OrderIndexViewModel> GetAll()
        {
            var orders = this.DbContext.Orders.Select(x => new OrderIndexViewModel
            {
                Id = x.Id,
                ClientId = x.Client.FirstName,
                ProductId = x.Product.Name,
                Quantity = x.Quantity,
                Total = x.Quantity * x.Product.Price


            }).ToList();

            return orders;
        }

        public TEntity GetById<TEntity>(int id)
        {
            var order = this.DbContext.Orders.Find(id);

            if (order == null)
            {
                //TODO order does not exist
            }

            var orderToReturn = this.Mapper.Map<TEntity>(order);

            return orderToReturn;
        }

        public DetailsOrderViewModel GetDetails(int id)
        {
            var order = this.DbContext.Orders.Where(x => x.Id == id)
                .Select(x => new DetailsOrderViewModel
                {
                    Id = x.Id,
                    OrderedOn = x.OrderedOn,
                    Quantity = x.Quantity,
                    Product = x.Product.Name,
                    Client = x.Client.FirstName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                })
                .FirstOrDefault();

            return order;
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


        public async Task CreateAsync(OrderDTO order)
        {
            var orderToCreate = new Order();

            orderToCreate.OrderedOn = order.OrderedOn;
            orderToCreate.Quantity = order.Quantity;
            orderToCreate.ProductId = order.ProductId;
            orderToCreate.ClientId = order.ClientId;
            orderToCreate.CreatedOn = DateTime.UtcNow;

            await this.DbContext.AddAsync(orderToCreate);
            await this.DbContext.SaveChangesAsync();

        }



        public async Task<bool> UpdateAsync(int id, OrderDTO order)
        {
            var orderToUpdate = this.DbContext.Orders.Find(order.Id);

            if (order == null)
            {
                return false;
            }

            orderToUpdate.OrderedOn = order.OrderedOn;
            orderToUpdate.Quantity = order.Quantity;
            orderToUpdate.ProductId = order.ProductId;
            orderToUpdate.ClientId = order.ClientId;
            orderToUpdate.ModifiedOn = DateTime.UtcNow;

            this.DbContext.Update(orderToUpdate);
            await this.DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = this.GetById<Order>(id);

            if (order == null)
            {
                return false;
            }

            this.DbContext.Remove(order);
            await this.DbContext.SaveChangesAsync();

            return true;
        }
    }
}
