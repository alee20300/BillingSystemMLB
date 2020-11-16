using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        void IEntityTypeConfiguration<Doctor>.Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorId);
            builder.Property(d => d.DoctorId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("Doctor_Id");
            builder.Property(d => d.DoctorName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Doctor_Name");

        }
    }
}
