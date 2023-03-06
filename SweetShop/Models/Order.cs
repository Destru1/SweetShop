using System;

namespace SweetShop.Models
{
    public class Order : BaseModel
    {
        public DateTime OrderedOn { get; set; }

        public int Quantity { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }


    }
}
