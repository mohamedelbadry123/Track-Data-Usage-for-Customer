using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services.DTOs
{
    /// <summary>
    /// Represents a summary of a customer's data usage for the current month.
    /// This DTO is used for transferring data about a customer's usage from the service layer to the UI layer or other parts of the application.
    /// </summary>
    public class CustomerUsageOverviewDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the total data used by the customer in the current month, measured in gigabytes (GB).
        /// </summary>
        public decimal TotalDataUsed { get; set; }
    }

}
