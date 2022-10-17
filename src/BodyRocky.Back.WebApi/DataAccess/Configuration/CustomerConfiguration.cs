﻿using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BodyRocky.Back.WebApi.DataAccess.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .ToTable("Customer");

        builder
            .Property(customer => customer.FirstName)
            .IsRequired();
        
        builder
            .Property(customer => customer.LastName)
            .IsRequired();
        
        builder
            .Property(customer => customer.BirthDate)
            .IsRequired();
    }
}