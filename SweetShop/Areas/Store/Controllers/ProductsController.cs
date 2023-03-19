﻿using System;
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

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    public class ProductsController : StoreController
    {
        private readonly SweetShopDbContext dbContext;
        private readonly IProductService productService;
        private readonly IAllergenService allergenService;

        public ProductsController(SweetShopDbContext dbContext, IProductService productService, IAllergenService allergenService)
        {
            this.dbContext = dbContext;
            this.productService = productService;
            this.allergenService = allergenService;
        }


        public IActionResult Index(string keyword, decimal? startPrice, decimal? endPrice, string sortOrder)
        {
            var products = this.productService.GetAll();

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSort"] = sortOrder == "decimal" ? "price" : "decimal";

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;

                case "price":
                    products = products.OrderBy(x => x.Price);
                    break;
                default:
                    products = products.OrderBy(x => x.Name);
                    break;
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                products = products.Where(p => p.Name.ToUpper().Contains(keyword.ToUpper())
                || p.Price.ToString().Contains(keyword)).ToList();
            }

            if (startPrice.HasValue && endPrice.HasValue)
            {
                products = products.Where(p => p.Price >= startPrice && p.Price <= endPrice).OrderBy(p => p.Price).ToList();
            }
            return this.View(products);
        }

        public IActionResult GetRating(int id)
        {
            var product = this.productService.GetRating(id);

            if (product == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(product);
        }


        public IActionResult Details(int id)
        {
            var product = this.productService.GetDetails(id);

            if (product == null)
            {
                return this.RedirectToAction("Index");
            }
            return this.View(product);

        }


        public IActionResult Create()
        {
            var allergens = this.allergenService.GetAll().ToList();

            bool alergensAreEmpty = allergens.Count== 0;
            if (alergensAreEmpty)
            {
                this.TempData[INFORMATION_NOTIFICATION] = string.Format(INFO_PRODUCT);
                return this.RedirectToAction("Index");

            }
            var productsModel = new ProductDTO()
            {
                Allergens = allergens,
            };
            return this.View(productsModel);
        }


        [HttpPost]

        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (!this.ModelState.IsValid)
            {
                product.Allergens = this.allergenService.GetAll().ToList();
                return this.View(product);
            }
            await this.productService.CreateAsync(product);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_PRODUCT);

            return this.RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var productToUpdate = this.productService.GetById<ProductDTO>(id);

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }
            productToUpdate.Allergens = this.allergenService.GetAll().ToList();
            return this.View(productToUpdate);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, ProductDTO updateProduct)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateProduct);
            }
            var isUpdated = await this.productService.UpdateAsync(id, updateProduct);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_UPDATED_PRODUCT);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.productService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_PRODUCT);

            return this.RedirectToAction("Index");
        }




    }
}
