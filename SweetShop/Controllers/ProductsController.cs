using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SweetShop.Data;
using SweetShop.Models;
using SweetShop.Services;
using SweetShop.ViewModels;

namespace SweetShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SweetShopDbContext dbContext;
        private readonly IProductService productService;
        private readonly IAllergenService allergenService;

        public ProductsController(SweetShopDbContext dbContext,IProductService productService, IAllergenService allergenService)
        {
            this.dbContext = dbContext;
            this.productService = productService;
            this.allergenService = allergenService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Products.ToListAsync());
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

        // GET: Products/Create
        public  IActionResult Create()
        {
            var allergens = this.allergenService.GetAll().ToList();

            var productsModel = new ProductFormServiceModel()
            {
                Allergens = allergens,
            };
            return this.View(productsModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormServiceModel product)
        {
            if (!this.ModelState.IsValid)
            {
                product.Allergens = this.allergenService.GetAll().ToList();
                return this.View(product);
            }
            await this.productService.CreateAsync(product);

            return this.RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dbContext.Products
                .Include(a => a.ProductAllergen)
                .Where(i => i.Id == id)
                .SingleOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            //PopulateAllergenData(product);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImageURL,Price,Id,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return dbContext.Products.Any(e => e.Id == id);
        }

        //    public void PopulateAllergenData(Product product)
        //    {
        //        var allAlergens = _context.Allergens;
        //        var productsAllergen = new HashSet<int>(product.ProductAllergen.Select(x => x.Id));
        //        var viewModel = new List<ProductAllergenViewModel>();
        //        foreach (var allergen in allAlergens)
        //        {
        //            viewModel.Add(new ProductAllergenViewModel
        //            {
        //                AllergenId = allergen.Id,
        //                AllergenName = allergen.Name,
        //            });
        //        }
        //        ViewBag.ProductsAllergen = viewModel;
        //    }
        //}
    }
}
