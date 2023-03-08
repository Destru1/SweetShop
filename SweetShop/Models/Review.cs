namespace SweetShop.Models
{
    public class Review : BaseModel
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }
    }
}
