using SweetShop.Constants.ModelConstants;
using SweetShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ClientConstants.NAME_MIN_VALUE)]
        [MaxLength(ClientConstants.NAME_MAX_VALUE)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ClientConstants.NAME_MIN_VALUE)]
        [MaxLength(ClientConstants.NAME_MAX_VALUE)]
        public string LastName { get; set; }

        [Required]
        [MinLength(ClientConstants.CITY_MIN_VALUE)]
        [MaxLength(ClientConstants.CITY_MAX_VALUE)]
        public string City { get; set; }

        [Required]
        [MinLength(ClientConstants.ADDRESS_MIN_VALUE)]
        [MaxLength(ClientConstants.ADDRESS_MAX_VALUE)]
        public string Address { get; set; }

        [Required]
        [MinLength(ClientConstants.PHONE_NUMBER_MIN_VALUE)]
        [MaxLength(ClientConstants.PHONE_NUMBER_MAX_VALUE)]
        public string PhoneNumber { get; set; }

        [Required]
        public PersonEntity PersonEntity { get; set; }

        [Required]
        public int DistributorId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
