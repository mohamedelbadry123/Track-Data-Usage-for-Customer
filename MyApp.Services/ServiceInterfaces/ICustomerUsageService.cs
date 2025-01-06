using MyApp.Services.DTOs;

namespace MyApp.Services.ServiceInterfaces
{
    public interface ICustomerUsageService
    {
        /// <summary>
        /// Asynchronously retrieves an overview of data usage for all customers.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable of <see cref="CustomerUsageOverviewDTO"/>
        /// representing the data usage overview of each customer. This includes each customer's ID, full name, and total data used in the current month.
        /// </returns>
        /// <remarks>
        /// This method is intended for scenarios where an overview of all customers' data usage is required,
        /// such as generating reports or displaying usage statistics in a dashboard.
        /// Data is presented in gigabytes and reflects usage for the current billing cycle or month.
        /// </remarks>
        public Task<IEnumerable<CustomerUsageOverviewDTO>> GetCustomerUsageOverviewAsync();
    }
}
