using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvvmCross.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>

    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountId);
            builder.Property(a => a.AccountId)
                .ValueGeneratedOnAdd();
            builder.Property(a => a.AccountName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Account_Name");
            builder.Property(a => a.AccountCode)
                .HasColumnName("Account_Code")
                .HasMaxLength(10)
                .IsRequired();
                
        }

        
    }
}
