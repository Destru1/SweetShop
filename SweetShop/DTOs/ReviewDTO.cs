using SweetShop.Constants.ModelConstants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Име на клиент")]
        public int ClientId { get; set; }

        [Required]
        [DisplayName("Име на продукт")]
        public int ProductId { get; set; }

        [Required]
        [MinLength(ReviewConstants.DESCRIPTION_MIN_VALUE)]
        [MaxLength(ReviewConstants.DESCRIPTION_MAX_VALUE)]
        [DisplayName("Описание")]
        public string Description { get; set; }

        [Required]
        [Range(ReviewConstants.RATING_MIN_VALUE, ReviewConstants.RATING_MAX_VALUE)]
        [DisplayName("Оценка (1-10)")]
        public int Rating { get; set; }

    }
}
