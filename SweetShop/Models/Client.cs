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
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public PersonEntity PersonEntity { get; set; }

        public int DistributorId { get; set; }

        public string UserId { get; set; }

        public virtual Distributor Distributor { get; set; }

        public virtual ApplicationUser User { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}
