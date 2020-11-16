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
            builder.HasKey(s => s.AccountServicePriceId)
                ;
           
            builder.Property(s => s.AccountServicePriceId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("Account_Servive_Price_Id");
            

            builder.Property(s => s.Rate)
                .HasColumnType("decimal(5,2)");

            builder.Property(s => s.PatientAmmount)
                .HasColumnType("decimal(5,2)")
                .HasColumnName("Patient_Ammount");

            builder.Property(s => s.AccountAmmount)
                .HasColumnType("decimal(5,2)")
                .HasColumnName("Account_Ammount");
        }
    }
}
