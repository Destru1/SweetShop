using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SweetShop.Areas.Store.Controllers;
using SweetShop.Constants;
using SweetShop.Data;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    public class ClientsController : StoreController
    {
        private readonly IClientService clientService;
        private readonly IAdministratorService administratorService;
        private readonly IDistributorService distributorService;

        public ClientsController(IClientService clientService, IAdministratorService administratorService, IDistributorService distributorService)
        {
            this.clientService = clientService;
            this.administratorService = administratorService;
            this.distributorService = distributorService;
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE + "," + RolesConstants.DISTRIBUTOR_ROLE)]
        [HttpGet]
        public IActionResult Index(string keyword,string sortOrder)
        {
            var clients = this.clientService.GetAll();

            ViewData["FirstNameSort"] = String.IsNullOrEmpty(sortOrder) ? "first_name" : "";
            ViewData["LastNameSort"] = String.IsNullOrEmpty(sortOrder) ? "last_name" : "";
            ViewData["CitySort"] = String.IsNullOrEmpty(sortOrder) ? "city" : "";
            ViewData["DistributorSort"] = String.IsNullOrEmpty(sortOrder) ? "distributor" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(x => x.FirstName);
                    break;

                case "last_name":
                    clients = clients.OrderBy(x => x.LastName);
                    break;
                case "city":
                    clients = clients.OrderBy(x => x.City);
                    break;
                case "distributor":
                    clients = clients.OrderBy(x => x.Distributor);
                    break;
                default:
                    clients = clients.OrderBy(x => x.FirstName);
                    break;
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                clients = clients.Where(c => c.FirstName.ToUpper().Contains(keyword.ToUpper())
                || c.LastName.ToUpper().Contains(keyword.ToUpper())
                || c.City.ToUpper().Contains(keyword.ToUpper())
                || c.Distributor.ToUpper().Contains(keyword.ToUpper()))
                    .ToList();

            }

            return this.View(clients);
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE + "," + RolesConstants.DISTRIBUTOR_ROLE)]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var client = this.clientService.GetDetails(id);

            if (client == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(client);
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<UserViewModel> users = this.administratorService.GetAll();
            IEnumerable<DistributorIndexViewModel> distributors = this.distributorService.GetAll();

            if (distributors.Count() == 0)
            {
                this.TempData[INFORMATION_NOTIFICATION] = string.Format(INFO_CLIENT);
            }

            this.ViewBag.Users = users;
            this.ViewBag.Distributors = distributors;

            return this.View();
        }


        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpPost]

        public async Task<IActionResult> Create(ClientDTO client)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(client);
            }

            await this.clientService.CreateAsync(client);

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_ADDED_CLIENT);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var clientToUpdate = this.clientService.GetById<ClientDTO>(id);

            IEnumerable<UserViewModel> users = this.administratorService.GetAll();
            IEnumerable<DistributorIndexViewModel> distributors = this.distributorService.GetAll();


            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            this.ViewBag.Users = users;
            this.ViewBag.Distributors = distributors;

            return this.View(clientToUpdate);
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpPost]
        public async Task<IActionResult> Update(int id, ClientDTO updateClient)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateClient);
            }

            var isUpdated = await this.clientService.UpdateAsync(id, updateClient);

            if (!isUpdated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_UPDATED_CLIENT);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await this.clientService.DeleteAsync(id);

            if (!isDeleted)
            {
                return this.RedirectToAction("Index", "Home");
            }

            this.TempData[SUCCESS_NOTIFICATION] = string.Format(SUCCSESSFULLY_DELETED_CLIENT);

            return this.RedirectToAction("Index");
        }


    }
}
