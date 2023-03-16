using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Allergen : BaseModel
    {

        public Allergen()
        {
            this.ProductAllergen = new HashSet<ProductAllergen>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ProductAllergen> ProductAllergen { get; set; }
        
    }
}
