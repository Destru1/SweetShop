using SweetShop.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.ViewModels.Client
{
    public class DetailClientViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public PersonEntity PersonEntity { get; set; }

        public int DistributorId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set;}
    }
}
