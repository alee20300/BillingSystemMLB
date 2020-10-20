using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class AccountServicePriceConfiguration : IEntityTypeConfiguration<AccountServicePrice>
    {
        public void Configure(EntityTypeBuilder<AccountServicePrice> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
