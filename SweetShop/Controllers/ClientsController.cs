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
using SweetShop.ViewModels.Distributor;
using SweetShop.ViewModels.User;

using static SweetShop.Constants.NotificationsConstants;

namespace SweetShop.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            var clients = this.clientService.GetAll();

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

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<UserViewModel> users = this.clientService.GetUser();
            IEnumerable<DistributorIndexViewModel> distributors = this.clientService.GetDistributors();


            this.ViewBag.Users = users;
            this.ViewBag.Distributors = distributors;

            return this.View();
        }


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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var clientToUpdate = this.clientService.GetById<ClientDTO>(id);

            IEnumerable<UserViewModel> users = this.clientService.GetUser();
            IEnumerable<DistributorIndexViewModel> distributors = this.clientService.GetDistributors();


            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            this.ViewBag.Users = users;
            this.ViewBag.Distributors = distributors;

            return this.View(clientToUpdate);
        }


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
