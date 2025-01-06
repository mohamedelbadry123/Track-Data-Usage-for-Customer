using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Configuration
{
    public class UsageRecordConfiguration : IEntityTypeConfiguration<UsageRecords>
    {
        public void Configure(EntityTypeBuilder<UsageRecords> builder)
        {
            // Sets the table name for the UsageRecord entity
            builder.ToTable("UsageRecords");

            // Configures the Date field as required
            builder.Property(u => u.Date)
                   .IsRequired();

            // Configures the DataUsed with precision for the decimal type to represent gigabytes accurately
            builder.Property(u => u.DataUsed)
                   .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            // Configures the foreign key relationship to the Customer entity
            builder.HasOne(u => u.Customer)
                   .WithMany(c=> c.UsageRecords) // This needs to link to a collection if Customer contains a collection of UsageRecords
                   .HasForeignKey(u => u.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade); // Sets the deletion behavior, can be modified as needed
        }
    }
}
