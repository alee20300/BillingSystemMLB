using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class AtollConfiguration : IEntityTypeConfiguration<Atoll>
    {
        public void Configure(EntityTypeBuilder<Atoll> builder)
        {
            builder.HasKey(s => s.AtollId);
            builder.Property(s => s.AtollId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Atoll_Id");
            builder.Property(s => s.AtollName)
                .HasMaxLength(6)
                .HasColumnName("Atoll_Name");

            builder
                .HasData(new Atoll { AtollId = 1, AtollName = "G DH" });
        }
    }

}
