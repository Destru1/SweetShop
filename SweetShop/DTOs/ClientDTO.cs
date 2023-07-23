using SweetShop.Constants.ModelConstants;
using SweetShop.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ClientConstants.NAME_MIN_VALUE)]
        [MaxLength(ClientConstants.NAME_MAX_VALUE)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ClientConstants.NAME_MIN_VALUE)]
        [MaxLength(ClientConstants.NAME_MAX_VALUE)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(ClientConstants.CITY_MIN_VALUE)]
        [MaxLength(ClientConstants.CITY_MAX_VALUE)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [MinLength(ClientConstants.ADDRESS_MIN_VALUE)]
        [MaxLength(ClientConstants.ADDRESS_MAX_VALUE)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required]
        [MinLength(ClientConstants.PHONE_NUMBER_MIN_VALUE)]
        [MaxLength(ClientConstants.PHONE_NUMBER_MAX_VALUE)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Person entity")]
        public PersonEntity PersonEntity { get; set; }

        [Required]
        [DisplayName("Distributor")]
        public int DistributorId { get; set; }

        [Required]
        [DisplayName("User")]
        public string UserId { get; set; }
    }
}
