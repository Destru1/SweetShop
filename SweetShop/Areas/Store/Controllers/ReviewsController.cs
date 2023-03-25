using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Areas.Store.Controllers;
using SweetShop.Constants;
using SweetShop.DTOs;
using SweetShop.Services;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Client;
using SweetShop.ViewModels.Product;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN_ROLE + "," + RolesConstants.CLIENT_ROLE)]
    public class ReviewsController : StoreController
    {
        private readonly IReviewService reviewService;
        private readonly IClientService clientService;
        private readonly IProductService productService;

        public ReviewsController(IReviewService reviewService, IClientService clientService, IProductService productService)
        {
            this.reviewService = reviewService;
            this.clientService = clientService;
            this.productService = productService;
        }


        [HttpGet]
        public IActionResult Index(string sort)
        {
            ViewData["HighestRated"] = sort == "int" ? "top" : "int";
            ViewData["LowestRated"] = sort == "int" ? "low" : "int";


            var reviews = this.reviewService.GetAll();

            if (sort == "top")
            {
                reviews = reviews.OrderByDescending(r => r.Rating);

            }
            if (sort == "low")
            {
                reviews = reviews.Where(r => r.Rating < 5).ToList();
            }

            return this.View(reviews);
        }


        [Authorize(Roles = RolesConstants.CLIENT_ROLE)]
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<ProductIndexViewModel> products = this.productService.GetAll();
            IEnumerable<ClientIndexViewModel> clients = this.clientService.GetAll();

            this.ViewBag.Products = products;
            this.ViewBag.Clients = clients;

            return this.View();
        }

        [Authorize(Roles = RolesConstants.CLIENT_ROLE)]
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


        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
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
