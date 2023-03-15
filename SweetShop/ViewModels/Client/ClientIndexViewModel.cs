using System.ComponentModel;

namespace SweetShop.ViewModels.Client
{
    public class ClientIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        public string City { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public string Distributor { get; set; }

    }
}
