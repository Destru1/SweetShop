using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetShop.Models;

namespace SweetShop.Data.EntityTypeConfiguration
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(a => a.Allergens)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.AllergenId);
        }
    }
}
