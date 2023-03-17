using SweetShop.Constants.ModelConstants;
using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class DistributorDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DistributorConstants.NAME_MIN_VALUE)]
        [MaxLength(DistributorConstants.NAME_MAX_VALUE)]
        public string Name { get; set; }

        [Required]
        [MinLength(DistributorConstants.CITY_MIN_VALUE)]
        [MaxLength(DistributorConstants.CITY_MAX_VALUE)]
        public string City { get; set; }

        [Required]
        [MinLength(DistributorConstants.ADDRESS_MIN_VALUE)]
        [MaxLength(DistributorConstants.ADDRESS_MAX_VALUE)]
        public string Address { get; set; }

        [Required]
        [MinLength(DistributorConstants.PHONE_NUMBER_MAX_VALUE)]
        [MaxLength(DistributorConstants.PHONE_NUMBER_MAX_VALUE)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

       
    }
}
