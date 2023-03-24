using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Product
{
    public class DetailProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string  Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Снимка")]
        public string ImageURL { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public double AverageRating { get; set; }

        [DisplayName("Създадено на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променено на")]
        public DateTime? ModifiedOn { get; set; }

    }
}
