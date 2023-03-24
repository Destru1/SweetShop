using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Снимка")]
        public string ImageURL { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [DisplayName("Продажби")]
        public int TimesSold { get; set; }
    }
}
