namespace SweetShop.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

    }
}
