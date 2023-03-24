using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Order
{
    public class OrderIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Клиент")]
        public string ClientId { get; set; }

        [DisplayName("Продукт")]
        public string ProductId { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Общо")]
        public decimal Total { get; set; }

        [DisplayName("Дата на порърката")]
        public DateTime OrderedOn { get; set; }
    }
}
