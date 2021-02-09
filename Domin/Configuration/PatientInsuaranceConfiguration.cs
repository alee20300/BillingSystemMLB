using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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
