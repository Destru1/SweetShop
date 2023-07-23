using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [DisplayName("User")]
        public string UserName { get; set; }

        [DisplayName("Name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Created on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Role")]
        public string RoleName { get; set; }

    }
}
