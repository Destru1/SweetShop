using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetShop.Data
{
    public class SweetShopDbContext : IdentityDbContext
    {
        public SweetShopDbContext(DbContextOptions<SweetShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergen> Allergens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
