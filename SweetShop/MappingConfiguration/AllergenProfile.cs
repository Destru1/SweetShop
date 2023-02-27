using AutoMapper;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels;

namespace SweetShop.MappingConfiguration
{
    public class AllergenProfile : Profile
    {
        public AllergenProfile()
        {
            this.CreateMap<Allergen, AllAllergensViewModel>();

            this.CreateMap<CreateAllergenDTO, Allergen>();

            this.CreateMap<Allergen, DetailsAlergenViewModel>();
            this.CreateMap<UpdateAllergenDTO, Allergen>().ReverseMap();
        }
    }
}
