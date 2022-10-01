using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Address")
            .HasKey(address => address.AddressID);

        builder
            .Property(address => address.AddressFromDate)
            .IsRequired();
        
        builder
            .Property(address => address.AddressToDate)
            .IsRequired();
        
        builder
            .Property(address => address.Street)
            .HasMaxLength(400)
            .IsRequired();
    }
}