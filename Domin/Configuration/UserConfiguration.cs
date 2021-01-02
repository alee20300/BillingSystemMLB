using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(U => U.UserId);
            builder.Property(U => U.UserId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
