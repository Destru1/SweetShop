using SweetShop.Constants.ModelConstants;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Ordered on")]
        public DateTime OrderedOn { get; set; }

        [Required]
        [Range(OrderConstants.QUANTITY_MIN_VALUE, OrderConstants.QUANTITY_MAX_VALUE)]
       
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Client")]
        public int ClientId { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }
    }
}
