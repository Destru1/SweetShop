using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetShop.Areas.Store.Controllers;
using SweetShop.Constants;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.Services;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Product;

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
    public class OrdersController : StoreController
    {
        private readonly IOrderService orderService;
        private readonly IClientService clientService;
        private readonly IProductService productService;

        public OrdersController(IOrderService orderService,IClientService clientService,IProductService productService)
        {
            this.orderService = orderService;
            this.clientService= clientService;
            this.productService = productService;

        }

        [HttpGet]
        public IActionResult Index(string? ClientId, string? ProductId, DateTime? sortDate)
        {
            var orders = this.orderService.GetAll();

            if (!string.IsNullOrWhiteSpace(ClientId))
            {
                orders = orders.Where(o => o.ClientId.Contains(ClientId)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(ProductId))
            {
                orders = orders.Where(o => o.ProductId.Contains(ProductId)).ToList();
            }

            if (sortDate.HasValue)
            {
                orders = orders.Where(o => o.OrderedOn.Date.Equals(sortDate.Value));
            }


            return View(orders);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var order = this.orderService.GetDetails(id);

            if (order == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(order);
        }

        [HttpGet]

        public IActionResult Create()
        {
            IEnumerable<ProductIndexViewModel> products = this.productService.GetAll();
            IEnumerable<ClientIndexViewModel> clients = this.clientService.GetAll();

            if (products.Count() == 0 && clients.Count() == 0)
            {
                this.TempData[INFORMATION_NOTIFICATION] = string.Format(INFO_ORDER);
            }

            this.ViewBag.Products = products;
            this.ViewBag.Clients = clients;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(order);
            }

            await this.orderService.CreateAsync(order);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_ORDER);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var orderToUpdate = this.orderService.GetById<OrderDTO>(id);

            IEnumerable<ProductIndexViewModel> products = this.productService.GetAll();
            IEnumerable<ClientIndexViewModel> clients = this.clientService.GetAll();

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");

            }

            this.ViewBag.Products = products;
            this.ViewBag.Clients = clients;

            return this.View(orderToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, OrderDTO order)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(order);

            }
            var isUpdated = await this.orderService.UpdateAsync(id, order);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_UPDATED_ORDER);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.orderService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_ORDER);

            return this.RedirectToAction("Index");
        }
    }
}