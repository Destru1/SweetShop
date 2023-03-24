using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Review
{
    public class IndexReviewViewModel
    {
        public int Id { get; set; }

        [DisplayName("Клиент")]
        public string Client { get; set; }

        [DisplayName("Продукт")]
        public string Product { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Оценка")]
        public int Rating { get; set; }

        [DisplayName("Оценено на")]
        public DateTime CreatedOn { get; set; }

    }
}
