using System.Collections;
using System.Collections.Generic;

namespace SweetShop.ViewModels
{
    public class ProductFormServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int[] AllergensIds { get; set; }

        public ICollection<AllAllergensViewModel> Allergens { get; set; }
    }
}
