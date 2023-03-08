using System;
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

namespace SweetShop.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
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
            IEnumerable<ProductIdNameViewModel> products = this.reviewService.GetProducts();
            IEnumerable<ClientIndexViewModel> clients = this.reviewService.GetClients();

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

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var reviewToUpdate = this.reviewService.GetById<OrderDTO>(id);

            IEnumerable<ProductIdNameViewModel> products = this.reviewService.GetProducts();
            IEnumerable<ClientIndexViewModel> clients = this.reviewService.GetClients();

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

            return this.RedirectToAction("Index");
        }
    }
}
