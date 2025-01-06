using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Sets the table name for the Customer entity
            builder.ToTable("Customers");

            // Configures the FirstName as a required field with a maximum length
            builder.Property(c => c.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Configures the LastName as a required field with a maximum length
            builder.Property(c => c.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Configures the Email as a required field with a maximum length
            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

        }
    }
}
