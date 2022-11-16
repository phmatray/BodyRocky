using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.Server.DataAccess.Configuration;

public class ZipCodeConfiguration : IEntityTypeConfiguration<ZipCode>
{
    public void Configure(EntityTypeBuilder<ZipCode> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("ZipCode")
            .HasKey(code => code.ZipCodeID);

        builder
            .Property(zipcode => zipcode.Code)
            .IsRequired();

        builder
            .Property(zipcode => zipcode.Commune)
            .IsRequired();
        
        // make code and commune unique
        builder
            .HasIndex(zipcode => new
            {
                zipcode.Code,
                zipcode.Commune
            })
            .IsUnique();
    }
}