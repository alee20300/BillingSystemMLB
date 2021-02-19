using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{


    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {


        void IEntityTypeConfiguration<Service>.Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.ServiceId);
            builder.Property(s => s.ServiceId).ValueGeneratedOnAdd();



        }
    }
}
