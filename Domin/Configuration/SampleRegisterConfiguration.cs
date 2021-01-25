using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class SampleRegisterConfiguration : IEntityTypeConfiguration<SampleRegister>
    {
        public void Configure(EntityTypeBuilder<SampleRegister> builder)
        {
            builder.HasKey(s => s.ReisterId);
            builder.Property(s => s.ReisterId)
                .ValueGeneratedOnAdd().IsRequired();
            builder.Property(s => s.SampleNumber)
                .HasMaxLength(100).IsRequired();

            builder.Property(s => s.RecivedBy)
                .HasMaxLength(20).IsRequired();

           
        }
    }
}
