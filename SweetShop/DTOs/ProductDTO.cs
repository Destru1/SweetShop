using System.Collections.Generic;
using SweetShop.ViewModels;

namespace SweetShop.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int[] AllergensIds { get; set; }

        public ICollection<AllAllergensViewModel> Allergens { get; set; }
    }
}
