using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class OrderStatusConfiguration
    : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder
            .ToTable("OrderStatus")
            .HasKey(status => status.Code);

        builder
            .Property(status => status.Description)
            .IsRequired();
    }
}