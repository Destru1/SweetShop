using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetShop.Data
{
    public class SweetShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string
        , IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public SweetShopDbContext(DbContextOptions<SweetShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergen> Allergens { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAllergen> ProductAllergens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
