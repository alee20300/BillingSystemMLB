using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domin.Configuration
{
    

    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
       

        void IEntityTypeConfiguration<Service>.Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s=>s.Id);
        }
    }
}
