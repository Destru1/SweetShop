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

        [DisplayName("Име на клиент")]
        public string Client { get; set; }

        [DisplayName("Име на продукт")]
        public string Product { get; set; }

        [DisplayName("Създадено на")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Променено на")]
        public DateTime? ModifiedOn { get; set; }
    }
}
