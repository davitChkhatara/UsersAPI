using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(a => a.City)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(a => a.Street)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(a => a.Country)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
