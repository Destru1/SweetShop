using AutoMapper;
using SweetShop.Models;
using SweetShop.ViewModels.Product;
using System.Linq;

namespace SweetShop.MappingConfiguration
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product,DetailProductViewModel>();
            this.CreateMap<Product, ProductFormServiceModel>()
                .ForMember(sm => sm.AllergensIds,
                pfsm => pfsm.MapFrom(pa => pa.ProductAllergen.Select(pp => pp.AllergenId))).ReverseMap();
        }
    }
}
