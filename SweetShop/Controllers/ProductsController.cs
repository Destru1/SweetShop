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
using SweetShop.Services;

namespace SweetShop.Controllers
{
    public class ProductsController : Controller
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

        // GET: Products
        public IActionResult Index()
        {
            var products = this.productService.GetAll();

            return this.View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

      
        public IActionResult Create()
        {
            var allergens = this.allergenService.GetAll().ToList();

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

            return this.RedirectToAction("Index");
        }


        public  IActionResult Update(int id)
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

       public async Task<IActionResult> Update(int id,ProductDTO updateProduct)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateProduct);
            }
            var isUpdated = await this.productService.UpdateAsync(id,updateProduct);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.productService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index");
        }



       
    }
}
