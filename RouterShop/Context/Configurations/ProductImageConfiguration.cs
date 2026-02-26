using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouterShop.Models;

namespace RouterShop.Context.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder
                .HasIndex(pi => pi.ProductId)
                .IsUnique()
                .HasFilter("[DefaultImage] = 1");
        }
    }
}
