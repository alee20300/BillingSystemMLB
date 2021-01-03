using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class InsuaranceConfiguration : IEntityTypeConfiguration<Insuarance>

    {
        public void Configure(EntityTypeBuilder<Insuarance> builder)
        {
            builder.HasKey(i => i.InsuaranceId);
            builder.Property(i => i.InsuaranceId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(i => i.InsuaranceName)
                .HasMaxLength(50)
                .IsRequired();



        }
    }
}
