using System;

namespace SweetShop.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public int Quantity { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }
    }
}
