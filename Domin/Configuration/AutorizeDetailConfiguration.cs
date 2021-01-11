
using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class AutorizeDetailConfiguration : IEntityTypeConfiguration<AutorizeDetail>
    {
        public void Configure(EntityTypeBuilder<AutorizeDetail> builder)
        {
            builder.HasKey(m => m.AuthorizeDetailId);
        }
    }
}
