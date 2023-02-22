using System;

namespace SweetShop.ViewModels
{
    public class DetailsAlergenView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

      

        public DateTime? DeletedOn { get; set; }
    }
}
