using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Order
{
    public class DetailsOrderViewModel
    {
        public int Id { get; set; }

        [DisplayName("Ordered on")]
        public DateTime OrderedOn { get; set; }

       
        public int Quantity { get; set; }

       
        public string Client { get; set; }

       
        public string Product { get; set; }

        [DisplayName("Created on")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Updated on")]
        public DateTime? ModifiedOn { get; set; }
    }
}
