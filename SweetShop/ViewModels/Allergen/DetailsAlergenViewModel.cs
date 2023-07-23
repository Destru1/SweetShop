using SweetShop.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels
{
    public class DetailsAlergenViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Created on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated on")]
        public DateTime? ModifiedOn { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<ProductIdNameViewModel> Products { get; set; }
    }
}
