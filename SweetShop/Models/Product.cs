using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Product : BaseModel
    {

        public Product()
        {
            this.ProductAllergen = new HashSet<ProductAllergen>();
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int TimesSold { get; set; }

        public int Rating { get; set; }

        public int TimesRated { get; set; }

        public double AverageRating
        {
            get
            {
                if (TimesRated == 0)
                {
                    return 0;
                }
                return Rating / TimesRated;
            }
        }

        public ICollection<ProductAllergen> ProductAllergen { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews { get; set; }


    }
}
