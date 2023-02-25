namespace SweetShop.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public int AllergenId { get; set; }

        public Allergen Allergens { get; set; }
    }
}
