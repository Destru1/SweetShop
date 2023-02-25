namespace SweetShop.Models
{
    public class ProductAllergen : BaseModel
    {

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int AllergenId { get; set; }

        public virtual Allergen Allergen { get; set; }
    }
}
