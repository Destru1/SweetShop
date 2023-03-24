using SweetShop.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels.Distributor
{
    public class DetailsDistributorViewModel
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
        public string User { get; set; }

        [DisplayName("Създадено на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променено на")]
        public DateTime? ModifiedOn { get; set; }

        public int ClientId { get; set; }

        public IEnumerable<ClientIndexViewModel> Clients { get; set; }
    }
}
