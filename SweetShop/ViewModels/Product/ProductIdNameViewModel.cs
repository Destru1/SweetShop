using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class ProductIdNameViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }
    }
}
