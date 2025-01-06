using MyApp.Services.DTOs;

namespace MyApp.Web.ViewModels
{
    /// <summary>
    /// ViewModel representing an overview of customer data usage for display in a user interface.
    /// This class is structured to support rendering data usage details for multiple customers along with contextual information about the time period of the data.
    /// </summary>
    public class CustomerUsageOverviewViewModel
    {
        /// <summary>
        /// Gets or sets a collection of CustomerUsageOverviewDTO objects.
        /// Each DTO in this collection contains data usage information for an individual customer,
        /// such as customer ID, full name, and total data used for the current month.
        /// </summary>
        /// <remarks>
        /// This property is marked as required to ensure that the ViewModel always has data to display,
        /// preventing errors in views that depend on this data.
        /// </remarks>
        public required IEnumerable<CustomerUsageOverviewDTO> Customers { get; set; }

        /// <summary>
        /// Gets or sets the name of the current month, which contextualizes the customer usage data.
        /// This is used in the user interface to inform users of the period for the displayed data.
        /// </summary>
        /// <remarks>
        /// Marking this property as required ensures that the view always has contextual information about the data period,
        /// enhancing user comprehension and interaction with the displayed data.
        /// </remarks>
        public required string CurrentMonth { get; set; }
    }

}
