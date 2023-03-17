using SweetShop.Constants.ModelConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.DTOs
{
    public class CreateAllergenDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(AllergenConstants.NAME_MIN_VALUE)]
        [MaxLength(AllergenConstants.NAME_MAX_VALUE)]
        public string Name { get; set; }

        [Required]
        [MinLength(AllergenConstants.DESCRIPTION_MIN_VALUE)]
        [MaxLength(AllergenConstants.DESCRIPTION_MAX_VALUE)]
        public string Description { get; set; }




    }
}
