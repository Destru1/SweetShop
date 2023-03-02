using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserRoles = new HashSet<ApplicationUserRole>();
        }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
