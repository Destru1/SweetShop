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
            this.Distributors= new HashSet<Distributor>();
            this.Clients= new HashSet<Client>();
        }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<Distributor> Distributors { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
