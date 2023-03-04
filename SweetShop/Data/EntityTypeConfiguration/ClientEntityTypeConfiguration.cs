using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetShop.Models;

namespace SweetShop.Data.EntityTypeConfiguration
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
               .HasOne(c => c.User)
               .WithMany(u => u.Clients)
               .HasForeignKey(c => c.UserId);

            builder
                .HasOne(c => c.Distributor)
                .WithMany(d => d.Clients)
                .HasForeignKey(c => c.DistributorId);
        }
    }
}
