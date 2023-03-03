using SweetShop.Models;
using SweetShop.ViewModels.User;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShop.Services.Interfaces
{
    public interface IAdministratorService
    {
        IEnumerable<UserViewModel> GetAll();

        Task<bool> PromoteAsync(ApplicationUser user);
        Task<bool> DemoteAsync(ApplicationUser user);
    }
}
