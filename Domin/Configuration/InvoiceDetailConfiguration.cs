using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasKey(d => d.InvoiceDetailId);
            builder.Property(d => d.InvoiceDetailId)
                .ValueGeneratedOnAdd();

        }
    }
}
