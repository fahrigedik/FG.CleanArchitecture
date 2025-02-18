﻿using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

    }
}
