using AutoMapper;
using SweetShop.Models;
using SweetShop.ViewModels;

namespace SweetShop.MappingConfiguration
{
    public class AllergenProfile : Profile
    {
        public AllergenProfile()
        {
            this.CreateMap<Allergen, AllAllergensViewModel>();

            this.CreateMap<CreateAllergenBindingModel, Allergen>();

            this.CreateMap<Allergen, DetailsAlergenView>();
            this.CreateMap<UpdateAllergenBindingModel, Allergen>().ReverseMap();
        }
    }
}
