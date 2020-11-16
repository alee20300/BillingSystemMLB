using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
   public class CountryConfiguration : IEntityTypeConfiguration<Country>

    {

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.CountryId);
            builder.Property(c => c.CountryId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("Country_Id");
            builder.Property(c => c.CountryName)
                .HasColumnName("Country_Name")
                .IsRequired()
        .HasMaxLength(50);


            builder.HasData(new Country { CountryId=1, CountryName = "Maldives" });

        
           
        }
    }
}
 
