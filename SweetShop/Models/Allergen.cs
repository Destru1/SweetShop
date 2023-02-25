using System.Collections.Generic;

namespace SweetShop.Models
{
    public class Allergen : BaseModel
    {

        public Allergen()
        {
            this.ProductAllergen = new HashSet<ProductAllergen>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductAllergen> ProductAllergen { get; set; }

    }
}
