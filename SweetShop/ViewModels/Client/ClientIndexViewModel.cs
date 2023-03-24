using System.ComponentModel;

namespace SweetShop.ViewModels.Client
{
    public class ClientIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string FirstName { get; set; }

        [DisplayName("Презиме")]
        public string LastName { get; set; }

        [DisplayName("Град")]
        public string City { get; set; }

        [DisplayName("Телефонен номер")]
        public string PhoneNumber { get; set; }

        [DisplayName("Дистрибутор")]
        public string Distributor { get; set; }

    }
}
