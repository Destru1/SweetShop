using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Constants;
using SweetShop.Data;
using SweetShop.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Seeder
{
    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(IServiceScope serviceScope)
        {
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.Users.Any())
            {
                return;
            }

            var admin = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Email = UserConstants.ADMIN_EMAIL,
                UserName = UserConstants.ADMIN_EMAIL,
                CreatedOn = DateTime.UtcNow,
            };

            await userManager.CreateAsync(admin,UserConstants.ADMIN_PASSWORD);
            await userManager.AddToRoleAsync(admin, RolesConstants.ADMIN_ROLE);
        }
    }
}
