using Microsoft.Extensions.DependencyInjection;
using SweetShop.Data;
using System.Threading.Tasks;

namespace SweetShop.Seeder
{
    public interface ISeeder
    {
        Task SeedAsync(IServiceScope serviceScope);
    }
}
