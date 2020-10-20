using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class MemoDetailConfiguration : IEntityTypeConfiguration<MemoDetail>
    {
        public void Configure(EntityTypeBuilder<MemoDetail> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
