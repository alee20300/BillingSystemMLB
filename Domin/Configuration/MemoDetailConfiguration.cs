using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class MemoDetailConfiguration : IEntityTypeConfiguration<MemoDetail>
    {
        public void Configure(EntityTypeBuilder<MemoDetail> builder)
        {
            builder.HasKey(s => s.MemoDetailId);
            builder.Property(s => s.MemoDetailId)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("MemoDetail_Id");
            builder.Property(s => s.Qty)
                .HasDefaultValue(1);
            builder.Property(s => s.Rate)
                .HasColumnType("decimal(5, 2)");

            //builder.Property(s => s.PatientAmmount)
            //    .HasColumnType("decimal(5, 2)");

            //builder.Property(s => s.AccountAmmount)
            //    .HasColumnType("decimal(5, 2)");
        }
    }
}
