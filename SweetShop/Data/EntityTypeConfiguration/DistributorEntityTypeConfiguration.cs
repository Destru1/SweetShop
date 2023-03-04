using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetShop.Models;

namespace SweetShop.Data.EntityTypeConfiguration
{
    public class DistributorEntityTypeConfiguration : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder
                .HasOne(d => d.User)
                .WithMany(u => u.Distributors)
                .HasForeignKey(d => d.UserId);
               
        }
    }
}
