using SweetShop.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Client : BaseModel
    {

        public Client()
        {
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        public PersonEntity PersonEntity { get; set; }

        [Required]
        public int DistributorId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual Distributor Distributor { get; set; }

        public virtual ApplicationUser User { get; set; }


        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
