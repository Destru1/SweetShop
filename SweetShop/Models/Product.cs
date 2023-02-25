using System.Collections;
using System.Collections.Generic;

namespace SweetShop.Models
{
    public class Product : BaseModel
    {

        public Product()
        {
            this.ProductAllergen = new HashSet<ProductAllergen>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        
        public virtual ICollection<ProductAllergen> ProductAllergen { get; set; }
    }
}
