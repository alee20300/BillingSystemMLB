using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domin.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientId);
            builder.Property(p => p.PatientId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("Patient_Id");
            builder.Property(p => p.PatientName)
                .IsRequired()
                .HasColumnName("Patient_Name")
                .HasMaxLength(100);
            builder.Property(p => p.IdCardNumber)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(p => p.PermAddress)
                .HasMaxLength(100)
                .HasColumnName("Perm_Address");
            builder.Property(p => p.Contact)
                .HasColumnName("Contact_Number")
                .HasMaxLength(25);
            builder.Property(p => p.Sex)
                .HasMaxLength(6);
            builder.Property(p => p.Email)
                .HasMaxLength(100);





            builder
                 .HasData(new Patient()
                 {
                     PatientId = 1,
                     AtollId = 1,
                     CountryId = 1,
                     Contact = "9702030",
                     CreatedBy = "Ali",
                     Email = "Alee20300@gmail.com",
                     IslandId = 1,
                     DateOfBirth = DateTime.Now,
                     PatientName = "Ali Abdulla",
                     Sex = "M",
                     PermAddress = "Sandalwood",
                     IdCardNumber = "A301427"
                 });


        }
    }
}
