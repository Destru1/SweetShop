using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Distributor : BaseModel
    {
        public Distributor()
        {
            this.Clients = new HashSet<Client>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
