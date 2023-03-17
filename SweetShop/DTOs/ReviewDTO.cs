using SweetShop.Constants.ModelConstants;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MinLength(ReviewConstants.DESCRIPTION_MIN_VALUE)]
        [MaxLength(ReviewConstants.DESCRIPTION_MAX_VALUE)]
        public string Description { get; set; }

        [Required]
        [Range(ReviewConstants.RATING_MIN_VALUE,ReviewConstants.RATING_MAX_VALUE)]
        public int Rating { get; set; }

    }
}
