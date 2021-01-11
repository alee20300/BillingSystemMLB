using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class UsernameAndHashConfiguration : IEntityTypeConfiguration<UsernameAndHash>
    {
        public void Configure(EntityTypeBuilder<UsernameAndHash> builder)
        {
            builder.HasKey(U => U.UsernameAndHashId);
        }
    }
}
