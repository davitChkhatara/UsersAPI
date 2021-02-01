using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "Users");

            builder.Property(c => c.PersonalId).HasMaxLength(11);
            builder.Property(c => c.HasJob);
            builder.Property(c => c.MonthlySalary).HasPrecision(18,2);
            builder.Property(c => c.Married);
        }
    }
}
