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
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    public class DistributorsController : StoreController
    {
        private readonly IDistributorService distributorService;

        public DistributorsController(IDistributorService distributorService)
        {
            this.distributorService = distributorService;
        }

        public IActionResult Index(string keyword)
        {

            var distributors = this.distributorService.GetAll();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                distributors = distributors.Where(d => d.Name.ToUpper().Contains(keyword.ToUpper()) 
                || d.City.ToUpper().Contains(keyword.ToUpper())).ToList();
            }
            return this.View(distributors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<UserViewModel> users = this.distributorService.GetUser();

            this.ViewBag.Users = users;
           
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DistributorDTO distributor)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(distributor);
            }
            await this.distributorService.CreateAsync(distributor);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_DISTRIBUTOR);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var distributorToUpdate = this.distributorService.GetById<DistributorDTO>(id);

            IEnumerable<UserViewModel> users = this.distributorService.GetUser();

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewBag.Users = users;

            return this.View(distributorToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, DistributorDTO updateDistributor)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateDistributor);
            }
            var isUpdated = await this.distributorService.UpdateAsync(id, updateDistributor);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");

            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_UPDATED_DISTRIBUTOR);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var distributor = this.distributorService.GetDetails(id);

            if (distributor == null)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View(distributor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.distributorService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_DISTRIBUTOR);

            return this.RedirectToAction("Index");
        }
    }
}
