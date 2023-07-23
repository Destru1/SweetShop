using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SweetShop.Constants.ModelConstants;
using SweetShop.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SweetShop.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MinLength(ProductConstants.NAME_MIN_VALUE)]
        [MaxLength(ProductConstants.NAME_MAX_VALUE)]
        public string Name { get; set; }

        [Required]
        [MinLength(ProductConstants.DESCRIPTION_MIN_VALUE)]
        [MaxLength(ProductConstants.DESCRIPTION_MAX_VALUE)]
        
        public string Description { get; set; }

        [Required]
        [Url]
        [DisplayName("Image")]
        public string ImageURL { get; set; }



        [Required]
        [Range(ProductConstants.PRICE_MIN_VALUE,ProductConstants.PRICE_MAX_VALUE)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
       
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Allergens")]
        public int[] AllergensIds { get; set; }

        public ICollection<AllAllergensViewModel> Allergens { get; set; }
    }
}
