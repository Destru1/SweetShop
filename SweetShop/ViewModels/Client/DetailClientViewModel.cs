using SweetShop.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.ViewModels.Client
{
    public class DetailClientViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public PersonEntity PersonEntity { get; set; }

        public string DistributorId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set;}
    }
}
