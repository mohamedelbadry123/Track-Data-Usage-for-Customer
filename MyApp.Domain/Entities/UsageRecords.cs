namespace MyApp.Domain.Entities
{
    public class UsageRecords : BaseEntity
    {
        // Date of the usage record
        public DateTime Date { get; set; }

        // Amount of data used in gigabytes
        public decimal DataUsed { get; set; }

        // Navigation property for the related Customer entity
        public required Customer Customer { get; set; }

        // Foreign key linking to the Customer entity
        public int CustomerID { get; set; }
    }
}
