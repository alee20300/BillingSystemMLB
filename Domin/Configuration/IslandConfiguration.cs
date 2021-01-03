using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class IslandConfiguration : IEntityTypeConfiguration<Island>
    {
        public void Configure(EntityTypeBuilder<Island> builder)
        {
            builder.HasKey(s => s.IslandId);
            builder.Property(s => s.IslandId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("Island_Id");
            builder.Property(s => s.IslandName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Island_Name");

            builder
               .HasData(new Island() { AtollId = 1, IslandId = 1, IslandName = "Thinadhoo" });

        }
    }
}
