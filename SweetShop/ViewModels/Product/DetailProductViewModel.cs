using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class DetailProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

      
        public string Description { get; set; }

        [DisplayName("Image")]
        public string ImageURL { get; set; }

       
        public decimal Price { get; set; }

        public string Allergen { get; set; }

        public double AverageRating { get; set; }

        [DisplayName("Created on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated on")]
        public DateTime? ModifiedOn { get; set; }

        
        public ICollection<AllAllergensViewModel> Allergens { get; set; }

    }
}
