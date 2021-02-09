using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{

    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {

            builder.HasKey(p => p.PaymentId);
            builder.Property(p => p.PaymentId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            

        }
    }
}

