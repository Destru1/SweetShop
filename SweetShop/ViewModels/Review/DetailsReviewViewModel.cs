using System;

namespace SweetShop.ViewModels.Review
{
    public class DetailsReviewViewModel
    {
        public int Id { get; set; }

        public string Client { get; set; }

        public string Product { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
