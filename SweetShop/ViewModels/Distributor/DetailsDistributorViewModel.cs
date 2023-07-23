using SweetShop.ViewModels.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels.Distributor
{
    public class DetailsDistributorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public string User { get; set; }

        [DisplayName("Created on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated on")]
        public DateTime? ModifiedOn { get; set; }

        public int ClientId { get; set; }

        public IEnumerable<ClientIndexViewModel> Clients { get; set; }
    }
}
