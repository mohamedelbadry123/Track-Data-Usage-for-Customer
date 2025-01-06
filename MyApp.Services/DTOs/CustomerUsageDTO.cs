using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services.DTOs
{
    public class CustomerUsageDTO
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
        /// Gets or sets the total data used by the customer in gigabytes (GB).
        /// This represents the sum of data used over a certain period or across multiple billing cycles.
        /// </summary>
        public decimal TotalDataUsed { get; set; }

        /// <summary>
        /// Gets or sets the data limit for the customer in gigabytes (GB).
        /// This is typically the data quota allocated to the customer as per their subscription plan.
        /// </summary>
        public decimal DataLimit { get; set; }
    }
}
