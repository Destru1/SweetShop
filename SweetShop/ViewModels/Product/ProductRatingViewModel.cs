using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class ProductRatingViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Средна оценка")]
        public double AverageRating { get; set; }
    }
}
