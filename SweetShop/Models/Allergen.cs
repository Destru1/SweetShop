using System.Collections;
using System.Collections.Generic;

namespace SweetShop.Models
{
    public class Allergen : BaseModel
    {
        public Allergen()
        {
            this.Products = new HashSet<Product>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
