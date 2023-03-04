using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.DTOs
{
    public class DistributorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

       
    }
}
