﻿using SweetShop.ViewModels.Client;
using System;
using System.Collections.Generic;

namespace SweetShop.ViewModels.Distributor
{
    public class DetailsDistributorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string User { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int ClientId { get; set; }

        public IEnumerable<ClientIndexViewModel> Clients { get; set; }
    }
}
