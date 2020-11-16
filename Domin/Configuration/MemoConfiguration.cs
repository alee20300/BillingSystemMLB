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
            builder.HasKey(m => m.MemoId);
            builder
               .HasOne(p => p.Patient)
               .WithMany(m => m.Memos);
            builder.Property(m => m.MemoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Memo_Id")
                .IsRequired();
            builder.Property(m => m.PatientName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Patient_Name");
            builder.Property(m => m.Address)
                .HasColumnName("Address")
                .HasMaxLength(100);
            builder.Property(m => m.Rate)
                .HasColumnType("decimal(5, 2)");
            builder.Property(m => m.PatientAmmount)
                .HasColumnType("decimal(5, 2)");
            builder.Property(m => m.AccountAmmount)
                .HasColumnType("decimal(5, 2)");


        }
    }
}
