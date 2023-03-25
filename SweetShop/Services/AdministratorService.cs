using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using SweetShop.Constants;
using SweetShop.Data;
using SweetShop.Models;
using SweetShop.Services.Interfaces;
using SweetShop.ViewModels.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Services
{
    public class AdministratorService : BaseService, IAdministratorService
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AdministratorService(SweetShopDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager) : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }


        public IEnumerable<UserViewModel> GetAll()
        {
            var userToReturn = this.DbContext.Users.ProjectTo<UserViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();

            return userToReturn;
        }

        public async Task<bool> PromoteAsync(ApplicationUser user)
        {
            var result = await this.AssignHigherRole(user);

            var oldRole = result.oldRole;
            var newRole = result.newRole;

            bool isPromoted = await this.SetNewRole(user, oldRole, newRole);

            return isPromoted;
        }

        public async Task<bool> DemoteAsync(ApplicationUser user)
        {
            var result = await this.AssignLowerRole(user);

            var oldRole = result.oldRole;
            var newRole = result.newRole;

            bool isDemoted = await this.SetNewRole(user, oldRole, newRole);

            return isDemoted;

        }

        private async Task<bool> SetNewRole(ApplicationUser user, string oldRole, string newRole)
        {
            bool isEmpty = string.IsNullOrEmpty(oldRole) && string.IsNullOrEmpty(newRole);

            if (isEmpty)
            {
                return false;
            }

            await this.userManager.RemoveFromRoleAsync(user, oldRole);
            await this.userManager.AddToRoleAsync(user, newRole);

            return true;
        }

        private async Task<(string oldRole, string newRole)> AssignHigherRole(ApplicationUser user)
        {
            var userRoles = await this.userManager.GetRolesAsync(user);

            var oldRole = string.Empty;
            var newRole = string.Empty;

            if (userRoles.Contains(RolesConstants.CLIENT_ROLE))
            {
                oldRole = RolesConstants.CLIENT_ROLE;
                newRole = RolesConstants.DISTRIBUTOR_ROLE;
            }

            else if (userRoles.Contains(RolesConstants.DISTRIBUTOR_ROLE))
            {
                oldRole = RolesConstants.DISTRIBUTOR_ROLE;
                newRole = RolesConstants.ADMIN_ROLE;
            }

            return (oldRole, newRole);
        }


        private async Task<(string oldRole, string newRole)> AssignLowerRole(ApplicationUser user)
        {
            var userRoles = await this.userManager.GetRolesAsync(user);

            var oldRole = string.Empty;
            var newRole = string.Empty;

            if (userRoles.Contains(RolesConstants.DISTRIBUTOR_ROLE))
            {
                oldRole = RolesConstants.DISTRIBUTOR_ROLE;
                newRole = RolesConstants.CLIENT_ROLE;
            }
            else if (userRoles.Contains(RolesConstants.ADMIN_ROLE))
            {
                oldRole = RolesConstants.ADMIN_ROLE;
                newRole = RolesConstants.DISTRIBUTOR_ROLE;
            }
            return (oldRole, newRole);
        }

    }
}
