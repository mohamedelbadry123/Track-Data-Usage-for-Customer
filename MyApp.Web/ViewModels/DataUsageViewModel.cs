namespace MyApp.Web.ViewModels
{
    /// <summary>
    /// Represents the data usage information for a customer in a view model format,
    /// typically used for displaying data in a user interface.
    /// </summary>
    public class DataUsageViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the total amount of data that the customer has used, expressed in gigabytes (GB).
        /// This includes data used in the current billing period.
        /// </summary>
        public decimal TotalDataUsed { get; set; }

        /// <summary>
        /// Gets or sets the data limit set for the customer's current plan, expressed in gigabytes (GB).
        /// This defines the total data volume the customer can use without incurring extra charges or throttling.
        /// </summary>
        public decimal DataLimit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer's data usage is near the set data limit.
        /// This can be used in the UI to warn the user or suggest actions.
        /// </summary>
        public bool IsNearLimit { get; set; }

        /// <summary>
        /// Gets or sets a recommended plan name that the customer should consider upgrading to,
        /// based on their current data usage patterns. This is used for upselling or informing customers
        /// of more suitable data plans.
        /// </summary>
        public required string RecommendedPlan { get; set; }
    }

}
