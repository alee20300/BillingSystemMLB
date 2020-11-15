using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
       public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientId)
                ;
           builder
                .HasData(new Patient() { AtollId = 1, countryId = 1, Contact = "9702030", 
                    CreatedBy = "Ali", Email = "Alee20300@gmail.com", IslandId = 1, DateOfBirth = DateTime.Now, 
                    Name = "Ali Abdulla", Sex = "M", PermAddress = "Sandalwood" });


        }
    }
}
