using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaims>
    {
        public void Configure(EntityTypeBuilder<RoleClaims> builder)
        {
            builder.HasKey(Ur => Ur.RoleClaimId);
            builder.HasOne(Ur => Ur.Role)
                .WithMany(u => u.RoleClaims)
                ;
            builder.HasOne(Ur => Ur.Claim)
               .WithMany(u => u.RoleClaims)
              ;
        }
    }
}
