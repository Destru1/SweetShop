using System;
using System.ComponentModel;

namespace SweetShop.ViewModels.Review
{
    public class IndexReviewViewModel
    {
        public int Id { get; set; }

        
        public string Client { get; set; }

        
        public string Product { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        [DisplayName("Reviewed on")]
        public DateTime CreatedOn { get; set; }

    }
}
