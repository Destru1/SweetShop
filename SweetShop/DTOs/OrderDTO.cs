using SweetShop.Constants.ModelConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        [Required]
        [Range(OrderConstants.QUANTITY_MIN_VALUE,OrderConstants.QUANTITY_MAX_VALUE)]
        public int Quantity { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
