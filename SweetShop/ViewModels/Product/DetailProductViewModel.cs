using System;

namespace SweetShop.ViewModels.Product
{
    public class DetailProductViewModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
