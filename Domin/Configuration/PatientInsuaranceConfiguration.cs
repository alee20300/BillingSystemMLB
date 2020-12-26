using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domin.Configuration
{
    public class PatientInsuaranceConfiguration : IEntityTypeConfiguration<PatientInsuarance>
    {
        public void Configure(EntityTypeBuilder<PatientInsuarance> builder)
        {
            builder.HasKey(p => p.PatientInsuaranceId);




        }
    }
}
