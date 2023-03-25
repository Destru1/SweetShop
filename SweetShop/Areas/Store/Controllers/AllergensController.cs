﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Areas.Store.Controllers;
using SweetShop.Constants;
using SweetShop.DTOs;
using SweetShop.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    [Authorize]
    public class AllergensController : StoreController
    {
        private readonly IAllergenService allergenService;

        public AllergensController(IAllergenService allergenService)
        {
            this.allergenService = allergenService;
        }


        [HttpGet]
        public IActionResult Index(string keyword, string sortOrder)
        {
            var allergens = this.allergenService.GetAll();

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DescriptionSort"] = String.IsNullOrEmpty(sortOrder) ? "desc_sort" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    allergens = allergens.OrderByDescending(x => x.Name);
                    break;

                case "desc_sort":
                    allergens = allergens.OrderByDescending(x => x.Description);
                    break;
                default:
                    allergens = allergens.OrderBy(x => x.Name);
                    break;
            }
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                allergens = allergens.Where(a => a.Name.ToUpper().Contains(keyword.ToUpper())
                || a.Description.ToUpper().Contains(keyword.ToUpper())).ToList();
            }

            return this.View(allergens);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var allergen = this.allergenService.GetDetails(id);
            if (allergen == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(allergen);
        }


        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpPost]

        public async Task<IActionResult> Create(CreateAllergenDTO alleren)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(alleren);
            }

            await this.allergenService.CreateAsync(alleren);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_ALLERGEN);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
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

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
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
            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_UPDATED_ALLERGEN);
            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.allergenService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_ALLERGEN);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
