﻿using System.Collections;
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
        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
