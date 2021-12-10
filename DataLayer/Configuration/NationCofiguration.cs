using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Configuration
{
    public class NationCofiguration : IEntityTypeConfiguration<Nation>
    {
        public void Configure(EntityTypeBuilder<Nation> builder)
        {
            builder.HasMany(a => a.Customers).WithOne(a => a.Nation).HasForeignKey(a => a.NationId);
            builder.HasData(
    new Nation { Id = 1, NationCode = "+98", NationType = "IR", NationTypeDesc = "IR(+98)" },
    new Nation { Id = 2, NationCode = "+1", NationType = "US", NationTypeDesc = "US(+1)" });
        }
    }
}
