﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Product;

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = this.orderService.GetAll();

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
            IEnumerable<ProductIdNameViewModel> products = this.orderService.GetProducts();
            IEnumerable<ClientIndexViewModel> clients = this.orderService.GetClients();

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

            IEnumerable<ProductIdNameViewModel> products = this.orderService.GetProducts();
            IEnumerable<ClientIndexViewModel> clients = this.orderService.GetClients();

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