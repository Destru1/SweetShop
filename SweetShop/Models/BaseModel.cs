﻿using System;

namespace SweetShop.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
