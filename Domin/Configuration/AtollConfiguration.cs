using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class AtollConfiguration : IEntityTypeConfiguration<Atoll>
    {
        public void Configure(EntityTypeBuilder<Atoll> builder)
        {
            builder.HasKey(s => s.Id);
            builder
                .HasData(new Atoll { Id = 1, AtollName = "G DH" });
        }
    }

}
