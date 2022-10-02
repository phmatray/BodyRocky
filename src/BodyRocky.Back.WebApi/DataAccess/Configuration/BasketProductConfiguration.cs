using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Namotion.Reflection;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class BasketProductConfiguration : IEntityTypeConfiguration<BasketProduct>
{
    public void Configure(EntityTypeBuilder<BasketProduct> builder)
    {
        builder.HasKey(bp => new { bp.BasketId, bp.ProductId });

        builder
            .HasOne(bp => bp.Basket)
            .WithMany(b => b.BasketProducts)
            .HasForeignKey(bp => bp.BasketId);

        builder
            .HasOne(bp => bp.Product)
            .WithMany(p => p.BasketProducts)
            .HasForeignKey(bp => bp.ProductId);

        builder
            .Property(bp => bp.Quantity)
            .HasDefaultValue(1);
    }
}