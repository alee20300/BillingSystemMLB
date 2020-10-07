using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class AuditEntityConfiguration : IEntityTypeConfiguration<AuditEntity>
    {
       public void Configure(EntityTypeBuilder<AuditEntity> builder)
        {
            builder.Property(a => a.LastModifeid)
                .HasMaxLength(10);

        }
    }
}
