using SweetShop.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels
{
    public class DetailsAlergenViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Създаден на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променен на")]
        public DateTime? ModifiedOn { get; set; }

        public int ProductId { get; set; }

        public IEnumerable<ProductIdNameViewModel> Products { get; set; }
    }
}
