using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SweetShop.Seeder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Seeders
{
    public static class Launcher
    {
        public static async Task SeedDataBase(IApplicationBuilder applicationBuilder)
        {
            ICollection<ISeeder> seeders = new List<ISeeder>()
            {
                new RoleSeeder(),
                new UserSeeder(),
            };

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                foreach (var seeder in seeders)
                {
                    await seeder.SeedAsync(serviceScope);
                }
            }
        }
    }
}
