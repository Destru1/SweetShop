using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Constants;
using SweetShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Seeder
{
    public class RoleSeeder : ISeeder
    {

        public async Task SeedAsync(IServiceScope serviceScope)
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (roleManager.Roles.Any())
            {
                return;
            }

            var roles = new List<ApplicationRole>()
           {
               new ApplicationRole(RolesConstants.CLIENT_ROLE),
               new ApplicationRole(RolesConstants.DISTRIBUTOR_ROLE),
               new ApplicationRole(RolesConstants.ADMIN_ROLE),
           };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

        }
    }
}
