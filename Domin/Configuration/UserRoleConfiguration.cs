using Domin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domin.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(Ur => Ur.UserRoleId);
            builder.HasOne(Ur => Ur.Role)
                .WithMany(u => u.UserRoles)
                ;
            builder.HasOne(Ur => Ur.User)
               .WithMany(u => u.UserRoles)
              ;
        }
    }
}
