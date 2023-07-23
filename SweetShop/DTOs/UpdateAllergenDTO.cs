using SweetShop.Constants.ModelConstants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class UpdateAllergenDTO
    {
        public int Id { get; set; }

        [MinLength(AllergenConstants.NAME_MIN_VALUE)]
        [MaxLength(AllergenConstants.NAME_MAX_VALUE)]
        public string Name { get; set; }

        [MinLength(AllergenConstants.DESCRIPTION_MIN_VALUE)]
        [MaxLength(AllergenConstants.DESCRIPTION_MAX_VALUE)]
        public string Description { get; set; }
    }
}
