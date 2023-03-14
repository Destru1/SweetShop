using SweetShop.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.ViewModels.Client
{
    public class DetailClientViewModel
    {
        public int Id { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public PersonEntity PersonEntity { get; set; }

        [DisplayName("Distributor")]
        public string DistributorId { get; set; }

        [DisplayName("User")]
        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set;}
    }
}
