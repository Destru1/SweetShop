using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Constants;
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

            var distributor = new ApplicationUser
            {
                FirstName = "Distributor",
                LastName = "Distributorov",
                Email = UserConstants.DISTRIBUTOR_EMAIL,
                UserName = UserConstants.DISTRIBUTOR_EMAIL,
                CreatedOn = DateTime.UtcNow,
            };
            var client = new ApplicationUser
            {
                FirstName = "Client",
                LastName = "Clientov",
                Email = UserConstants.CLIENT_EMAIL,
                UserName = UserConstants.CLIENT_EMAIL,
                CreatedOn = DateTime.UtcNow,
            };

            await userManager.CreateAsync(admin, UserConstants.ADMIN_PASSWORD);
            await userManager.AddToRoleAsync(admin, RolesConstants.ADMIN_ROLE);

            await userManager.CreateAsync(distributor, UserConstants.DISTRIBUTOR_PASSWORD);
            await userManager.AddToRoleAsync(distributor, RolesConstants.DISTRIBUTOR_ROLE);

            await userManager.CreateAsync(client, UserConstants.CLIENT_PASSWORD);
            await userManager.AddToRoleAsync(client, RolesConstants.CLIENT_ROLE);
        }
    }
}
