﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Constants;
using SweetShop.Controllers;
using SweetShop.Models;
using SweetShop.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Areas.Administrator.Controllers
{
    [Authorize(Roles = RolesConstants.ADMIN_ROLE)]
    public class DashboardController : AdministratorController
    {
        private readonly IAdministratorService administratorService;
        private readonly UserManager<ApplicationUser> userManager;

        public DashboardController(IAdministratorService administratorService, UserManager<ApplicationUser> userManager)
        {
            this.administratorService = administratorService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            var users = administratorService.GetAll();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                users = users.Where(u => u.UserName.ToUpper().Contains(keyword.ToUpper())
                || u.FirstName.ToUpper().Contains(keyword.ToUpper())
                || u.LastName.ToUpper().Contains(keyword.ToUpper())
                || u.RoleName.ToUpper().Contains(keyword.ToUpper()))
                .ToList();
            }

            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> Promote(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                //Todo user does not exist message

                return RedirectToAction(nameof(this.Index));
            }

            var isPromoted = await administratorService.PromoteAsync(user);

            if (!isPromoted)
            {
                //Todo not promoted message

                return RedirectToAction(nameof(this.Index));
            }

            return RedirectToAction(nameof(this.Index));

        }

        [HttpPost]
        public async Task<IActionResult> Demote(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return RedirectToAction(nameof(this.Index));
            }

            var isDemoted = await administratorService.DemoteAsync(user);

            if (!isDemoted)
            {
                //Todo not demoted message
                return RedirectToAction(nameof(this.Index));
            }

            //Todo demoted message
            return RedirectToAction(nameof(this.Index));
        }
    }
}
