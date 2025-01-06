using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Configuration;
using System.Numerics;

namespace MyApp.Data.Context
{
    /// <summary>
    /// Represents the application's database context.
    /// Inherits from IdentityDbContext to include Identity-related tables and configurations.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPlan> CustomerPlan { get; set; }
        public DbSet<UsageRecords> UsageRecords { get; set; }

        /// <summary>
        /// Configures the model by applying entity configurations and Identity-related settings.
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder instance used to configure entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calls the base method to apply IdentityDbContext configurations (e.g., for ASP.NET Identity tables).
            base.OnModelCreating(modelBuilder);

            // Configure foreign key relationships for BaseEntity
            modelBuilder.Entity<BaseEntity>(builder =>
            {
                // Configure CreatedById as a foreign key to AspNetUsers.Id
                builder.HasOne<IdentityUser>()
                       .WithMany()
                       .HasForeignKey(e => e.CreatedById)
                       .OnDelete(DeleteBehavior.Restrict) // Prevent cascading deletes
                       .IsRequired(false);

                // Configure LastUpdatedById as a foreign key to AspNetUsers.Id
                builder.HasOne<IdentityUser>()
                       .WithMany()
                       .HasForeignKey(e => e.LastUpdatedById)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);
            });

            // Explicitly ignore the abstract BaseEntity
            modelBuilder.Ignore<BaseEntity>();

            // Apply configuration to the Plan entity
            modelBuilder.ApplyConfiguration(new PlanConfiguration());

            // Apply the configuration to the Customer entity
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            // Apply the configuration to the CustomerPlan entity
            modelBuilder.ApplyConfiguration(new CustomerPlanConfiguration());

            // Apply the configuration to the UsageRecord entity
            modelBuilder.ApplyConfiguration(new UsageRecordConfiguration());
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationDbContext with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Constructor ensures that the DbContext is initialized with the given options (e.g., connection string).
        }
    }
}
