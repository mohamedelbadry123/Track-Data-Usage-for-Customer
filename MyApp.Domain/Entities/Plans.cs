namespace MyApp.Domain.Entities
{
    public class Plans : BaseEntity
    {
        // Name of the plan
        public required string PlanName { get; set; }

        // Data limit of the plan in gigabytes
        public decimal DataLimit { get; set; }

        public required ICollection<CustomerPlan> CustomerPlans { get; set; }

    }
}
