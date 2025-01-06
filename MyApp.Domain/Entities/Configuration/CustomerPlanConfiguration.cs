using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Configuration
{
    public class CustomerPlanConfiguration : IEntityTypeConfiguration<CustomerPlan>
    {
        public void Configure(EntityTypeBuilder<CustomerPlan> builder)
        {
            // Sets the table name for the CustomerPlan entity
            builder.ToTable("CustomerPlans");

            // Specifies the composite primary key
            builder.HasKey(cp => new { cp.CustomerID, cp.PlanID });

            // Configures the one-to-one relationship with Customer
            builder.HasOne(cp => cp.Customer)
                   .WithOne(c => c.CustomerPlan) 
                   .HasForeignKey<CustomerPlan>(cp => cp.CustomerID)
                   .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

            // Configures the one-to-many relationship with Plan
            builder.HasOne(cp => cp.Plan)
                   .WithMany(p => p.CustomerPlans) 
                   .HasForeignKey(cp => cp.PlanID)
                   .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete
        }
    }
}
