using System.Collections.Generic;

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
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductAllergen> ProductAllergen { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews { get; set; }


    }
}
