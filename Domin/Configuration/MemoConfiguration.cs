using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class MemoConfiguration : IEntityTypeConfiguration<Memo>

    {
        public void Configure(EntityTypeBuilder<Memo> builder)
        {
            builder.HasKey(m => m.MemoNumber);
        }
    }
}
