using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class BasketProductConfiguration : IEntityTypeConfiguration<BasketProduct>
{
    public void Configure(EntityTypeBuilder<BasketProduct> builder)
    {
        builder
            .ToTable("BasketProducts")
            .HasKey(bp => new { bp.BasketID, bp.ProductID });

        builder
            .HasOne(bp => bp.Basket)
            .WithMany(b => b.BasketProducts)
            .HasForeignKey(bp => bp.BasketID);

        builder
            .HasOne(bp => bp.Product)
            .WithMany(p => p.BasketProducts)
            .HasForeignKey(bp => bp.ProductID);

        builder
            .Property(bp => bp.Quantity)
            .HasDefaultValue(1);
    }
}