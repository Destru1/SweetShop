using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetShop.Areas.Store.Controllers;
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
    public class ReviewsController : StoreController
    {
        private readonly IReviewService reviewService;
        private readonly IClientService clientService;
        private readonly IProductService productService;

        public ReviewsController(IReviewService reviewService, IClientService clientService, IProductService productService)
        {
            this.reviewService = reviewService;
            this.clientService= clientService;
            this.productService= productService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var reviews = this.reviewService.GetAll();

            return this.View(reviews);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var review = this.reviewService.GetDetails(id);

            if (review == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(review);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<ProductIndexViewModel> products = this.productService.GetAll();
            IEnumerable<ClientIndexViewModel> clients = this.clientService.GetAll();

            this.ViewBag.Products = products;
            this.ViewBag.Clients = clients;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewDTO review)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(review);
            }

            await this.reviewService.CreateAsync(review);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_REVIEW);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var reviewToUpdate = this.reviewService.GetById<OrderDTO>(id);

            IEnumerable<ProductIndexViewModel> products = this.productService.GetAll();
            IEnumerable<ClientIndexViewModel> clients = this.clientService.GetAll();

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");

            }

            this.ViewBag.Products = products;
            this.ViewBag.Clients = clients;

            return this.View(reviewToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ReviewDTO order)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(order);

            }
            var isUpdated = await this.reviewService.UpdateAsync(id, order);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.reviewService.DeleteAsync(id);

            if (!isDeleted)
            {

                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_REVIEW);

            return this.RedirectToAction("Index");
        }
    }
}
