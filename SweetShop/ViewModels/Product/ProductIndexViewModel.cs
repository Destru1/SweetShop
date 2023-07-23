using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Image")]
        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [DisplayName("Sales")]
        public int TimesSold { get; set; }
    }
}
