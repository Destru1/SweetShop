using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Review : BaseModel
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Rating { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }
    }
}
