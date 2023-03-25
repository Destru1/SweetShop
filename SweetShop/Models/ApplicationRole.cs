using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SweetShop.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            this.UserRole = new HashSet<ApplicationUserRole>();
        }
        public ApplicationRole(string roleName)
            : base(roleName)
        {

        }

        public ICollection<ApplicationUserRole> UserRole { get; set; }
    }
}
