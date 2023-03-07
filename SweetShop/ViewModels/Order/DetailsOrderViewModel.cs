using System;

namespace SweetShop.ViewModels.Order
{
    public class DetailsOrderViewModel
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public int Quantity { get; set; }

        public string Client { get; set; }

        public string Product { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
