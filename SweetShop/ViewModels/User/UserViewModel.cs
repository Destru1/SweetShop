using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [DisplayName("Потребителско име")]
        public string UserName { get; set; }

        [DisplayName("Име")]
        public string FirstName { get; set; }

        [DisplayName("Презиме")]
        public string LastName { get; set; }

        [DisplayName("Създаден на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Роля")]
        public string RoleName { get; set; }

    }
}
