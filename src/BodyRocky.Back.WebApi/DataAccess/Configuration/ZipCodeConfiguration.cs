using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class ZipCodeConfiguration : IEntityTypeConfiguration<ZipCode>
{
    public void Configure(EntityTypeBuilder<ZipCode> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(zipcode => zipcode.Code)
            .IsRequired();

        builder
            .Property(zipcode => zipcode.Commune)
            .IsRequired();
    }
}