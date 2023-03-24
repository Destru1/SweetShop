using System.ComponentModel;

namespace SweetShop.ViewModels.Distributor
{
    public class DistributorIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Град")]
        public string City { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Телефонен номер")]
        public string PhoneNumber { get; set; }

        [DisplayName("Потребителско име")]
        public string UserName { get; set; }

    }
}
