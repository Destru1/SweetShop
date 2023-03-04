using AutoMapper;
using SweetShop.DTOs;
using SweetShop.Models;
using SweetShop.ViewModels.Distributor;

namespace SweetShop.MappingConfiguration
{
    public class DistributorProfile : Profile
    {
        public DistributorProfile()
        {
            this.CreateMap<Distributor, DistributorIndexViewModel>()
                .ForMember(d => d.UserName, conf => conf.MapFrom(s=> s.User.UserName)).ReverseMap();

            this.CreateMap<Distributor, DistributorDTO>()
                .ForMember(d => d.UserId, conf => conf.MapFrom(s => s.User.UserName)).ReverseMap();


        }
    }
}
