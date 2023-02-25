using AutoMapper;
using SweetShop.Models;
using SweetShop.ViewModels;
using System.Linq;

namespace SweetShop.MappingConfiguration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductFormServiceModel>()
                .ForMember(sm => sm.AllergensIds, 
                pfsm => pfsm.MapFrom(s => s.ProductAllergen.Select(cc => cc.AllergenId))).ReverseMap(); 
        }
    }
}
