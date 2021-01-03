using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class CollectionSiteConfiguration : IEntityTypeConfiguration<CollectionSite>
    {
        public void Configure(EntityTypeBuilder<CollectionSite> builder)
        {
            builder.HasKey(s => s.CollectionSIteID);
            builder.Property(s => s.CollectionSIteID)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(s => s.CollectionSiteName)
                .HasMaxLength(100);


        }
    }
}
