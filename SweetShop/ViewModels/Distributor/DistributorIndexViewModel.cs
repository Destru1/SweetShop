using System.ComponentModel;

namespace SweetShop.ViewModels.Distributor
{
    public class DistributorIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("User")]
        public string UserName { get; set; }

    }
}
