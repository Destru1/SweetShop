using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SweetShop.Areas.Identity.IdentityHostingStartup))]
namespace SweetShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}