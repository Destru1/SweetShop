using SweetShop.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace SweetShop.ViewModels
{
    public class DetailsAlergenViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<ProductIdNameViewModel> Products { get; set; }
    }
}
