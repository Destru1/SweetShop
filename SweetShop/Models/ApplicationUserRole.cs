using Microsoft.AspNetCore.Identity;

namespace SweetShop.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUser User { get; set; }

        public ApplicationRole Role { get; set; }
    }
}
