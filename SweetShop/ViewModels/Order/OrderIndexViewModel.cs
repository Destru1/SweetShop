using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Order
{
    public class OrderIndexViewModel
    {
        public int Id { get; set; }

        [DisplayName("Client")]
        public string ClientId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        [DisplayName("Ordered on")]
        public DateTime OrderedOn { get; set; }
    }
}
