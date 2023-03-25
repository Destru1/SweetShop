using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Order : BaseModel
    {
        public DateTime OrderedOn { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }


    }
}
