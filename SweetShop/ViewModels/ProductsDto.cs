using Microsoft.AspNetCore.Mvc.Rendering;
using SweetShop.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SweetShop.ViewModels
{
    public class ProductsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public List<SelectListItem> AllergenList { get; set; }

        [DisplayName("Allergens")]
        public int[] AlergenIds { get; set; }
    }
}
