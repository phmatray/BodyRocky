using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Basket")
            .HasKey(basket => basket.BasketID);

        builder
            .Property(basket => basket.BasketDateAdded)
            .IsRequired();
        
        builder
            .HasOne(basket => basket.BasketStatus)
            .WithMany(status => status.Baskets)
            .HasForeignKey(basket => basket.BasketStatusCode);
    }
}