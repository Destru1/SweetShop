using AutoMapper;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Review;

namespace SweetShop.MappingConfiguration
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            this.CreateMap<Review, ReviewDTO>();

            this.CreateMap<Review, IndexReviewViewModel>()
                .ForMember(vm => vm.Client, mf => mf.MapFrom(r => r.Client.FirstName))
                .ForMember(vm => vm.Product, mf => mf.MapFrom(r => r.Product.Name)).ReverseMap();
        }
    }
}
