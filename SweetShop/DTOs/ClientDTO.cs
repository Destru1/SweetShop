using SweetShop.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

       
        public string PhoneNumber { get; set; }

        public string PersonEntity { get; set; }

        public int DistributorId { get; set; }

        public string UserId { get; set; }
    }
}
