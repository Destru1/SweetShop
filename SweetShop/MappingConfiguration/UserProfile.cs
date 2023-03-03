using AutoMapper;
using SweetShop.Models;
using SweetShop.ViewModels.User;
using System.Linq;

namespace SweetShop.MappingConfiguration
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(r => r.RoleName, conf => conf.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()));
        }
    }
}
