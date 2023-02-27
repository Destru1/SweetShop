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
    public class AllergensController : Controller
    {
        private readonly IAllergenService allergenService;

        public AllergensController(IAllergenService allergenService)
        {
            this.allergenService = allergenService;
        }

        // GET: Allergens
        public  IActionResult Index()
        {
            var allergens = this.allergenService.GetAll();

            return this.View(allergens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateAllergenDTO alleren)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(alleren);
            }

            await this.allergenService.CreateAsync(alleren);
          

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var allergenToUpdate = this.allergenService.GetById<UpdateAllergenDTO>(id);
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
            return this.View(allergenToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAllergenDTO updateAllergen)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateAllergen);
            }
            var isUpdated = await allergenService.UpdateAsync(updateAllergen);

            if (!isUpdated)
            {
                this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) {
            var allergen = this.allergenService.GetDetails(id);
            if (allergen == null)
            {
                return this.RedirectToAction("Index","Home");
            }

            return this.View(allergen);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.allergenService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
