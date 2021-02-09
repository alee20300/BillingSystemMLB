using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class CatogoryConfiguration : IEntityTypeConfiguration<Catogory>
    {
        void IEntityTypeConfiguration<Catogory>.Configure(EntityTypeBuilder<Catogory> builder)
        {
            builder.HasKey(c => c.CatogoryId);
            builder.Property(c => c.CatogoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Catogory_ID");
            builder.Property(c => c.CatogoryName)
                .HasColumnName("Catogory_Name")
                .HasMaxLength(50);
            builder.Property(c => c.CatogoryCode)
                .HasMaxLength(6)
                .HasColumnName("Catogory_Id");


        }
    }
}
