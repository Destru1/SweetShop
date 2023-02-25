using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetShop.Models;

namespace SweetShop.Data.EntityTypeConfiguration
{
    public class ProductAllergenEntityTypeConfiguration : IEntityTypeConfiguration<ProductAllergen>
    {
        public void Configure(EntityTypeBuilder<ProductAllergen> builder)
        {
            builder
                 .HasOne(p => p.Product)
                 .WithMany(pa => pa.ProductAllergen)
                 .HasForeignKey(p => p.ProductId);

            builder
                .HasOne(a => a.Allergen)
                .WithMany(pa => pa.ProductAllergen)
                .HasForeignKey(a => a.AllergenId);
        }
    }
}
