using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Order
{
    public class DetailsOrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дата на поръчката")]
        public DateTime OrderedOn { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Клиент")]
        public string Client { get; set; }

        [DisplayName("Продукт")]
        public string Product { get; set; }

        [DisplayName("Създадено")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променено")]
        public DateTime? ModifiedOn { get; set; }
    }
}
