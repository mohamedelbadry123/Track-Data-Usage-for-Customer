using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Configuration
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plans>
    {
        public void Configure(EntityTypeBuilder<Plans> builder)
        {
            // Sets the table name for the Plan entity
            builder.ToTable("Plans");

            // Configures the PlanName as a required field with a maximum length
            builder.Property(p => p.PlanName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configures the DataLimit with precision and scale for decimal type
            builder.Property(p => p.DataLimit)
                   .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed
        }
    }
}
