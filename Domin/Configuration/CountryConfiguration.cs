﻿using Domin.Models;
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
            builder.HasKey(c => c.Id);
            builder.HasData(new Country { Id=1, CountryName = "Maldives" });

        
           
        }
    }
}
 