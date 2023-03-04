using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SweetShop.Models
{
    public class Distributor : BaseModel
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
