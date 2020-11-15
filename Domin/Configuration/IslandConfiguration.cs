using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class IslandConfiguration : IEntityTypeConfiguration<Island>
    {
        public void Configure(EntityTypeBuilder<Island> builder)
        {
            builder.HasKey(s => s.Id);

            builder
               .HasData(new Island() { AtollId = 1, Id = 1, IslandName = "Thinadhoo" });
           
        }
    }
}
