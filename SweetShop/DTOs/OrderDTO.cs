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
        [DisplayName("Дата на поръчката")]
        public DateTime OrderedOn { get; set; }

        [Required]
        [Range(OrderConstants.QUANTITY_MIN_VALUE,OrderConstants.QUANTITY_MAX_VALUE)]
        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Име на клиента")]
        public int ClientId { get; set; }

        [Required]
        [DisplayName("Име на продукта")]
        public int ProductId { get; set; }
    }
}
