using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class ProductRatingViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Average rating")]
        public double AverageRating { get; set; }
    }
}
