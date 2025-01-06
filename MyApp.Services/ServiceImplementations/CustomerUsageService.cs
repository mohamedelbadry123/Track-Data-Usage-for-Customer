using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Services.DTOs;
using MyApp.Services.ServiceInterfaces;

namespace MyApp.Services.ServiceImplementations
{
    public class CustomerUsageService : ICustomerUsageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerUsageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Asynchronously retrieves an overview of data usage for all customers for the current month.
        /// </summary>
        /// <returns>
        /// A task that, when completed successfully, returns an enumerable of <see cref="CustomerUsageOverviewDTO"/>.
        /// Each DTO contains the customer's ID, full name, and total data used for the current month.
        /// </returns>
        public async Task<IEnumerable<CustomerUsageOverviewDTO>> GetCustomerUsageOverviewAsync()
        {
            // Retrieve the current month and year to filter records relevant to the current period
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            // Asynchronously get all usage records from the repository
            var usageRecords = _unitOfWork.Repository<MyApp.Domain.Entities.UsageRecords>().GetAllAsync();

            // Filter, group, and project the usage records to the DTO format:
            return await usageRecords
                .Include(c=> c.Customer)
                .Where(u => u.Date.Month == currentMonth && u.Date.Year == currentYear) // Filter records to current month and year
                .GroupBy(u => u.CustomerID) // Group by CustomerID to aggregate data per customer
                .Select(group => new CustomerUsageOverviewDTO
                {
                    CustomerId = group.Key, // Set CustomerId from the group key
                    FullName = group.First().Customer.FirstName + " " + group.First().Customer.LastName, // Concatenate first and last name from the first record in the group
                    TotalDataUsed = group.Sum(u => u.DataUsed) // Sum up the data used for each group to get total data usage
                })
                .ToListAsync(); // Execute the query asynchronously and convert the result to a List
        }

    }
}
