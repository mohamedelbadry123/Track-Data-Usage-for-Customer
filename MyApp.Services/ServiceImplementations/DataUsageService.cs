using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Services.DTOs;
using MyApp.Services.ServiceInterfaces;

namespace MyApp.Services.ServiceImplementations
{
    public class DataUsageService : IDataUsageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DataUsageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Asynchronously retrieves the monthly data usage for a specific customer based on the provided month and year.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <param name="month">The month for which data usage needs to be fetched.</param>
        /// <param name="year">The year associated with the month for which data usage is fetched.</param>
        /// <returns>
        /// A <see cref="CustomerUsageDTO"/> object containing the data usage details if found, otherwise null.
        /// </returns>
        public async Task<CustomerUsageDTO?> GetMonthlyDataUsageAsync(int customerId, int month, int year)
        {
            // Define parameters to be passed to the stored procedure
            var parameters = new[]
            {
                new SqlParameter("@CustomerId", customerId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year)
            };

            // Construct the SQL query to execute the stored procedure
            var query = "EXEC dbo.GetMonthlyDataUsage @CustomerId, @Month, @Year";

            // Execute the query and obtain the first or default record asynchronously
            var usageRecord = await _unitOfWork.Context.Database
                                  .SqlQueryRaw<CustomerUsageDTO>(query, parameters)
                                  .FirstOrDefaultAsync();

            // Check if a usage record was found
            if (usageRecord != null)
            {
                // Map the data to a new CustomerUsageDTO object
                return new CustomerUsageDTO
                {
                    CustomerId = usageRecord.CustomerId,
                    FullName = $"{usageRecord.FullName}",
                    TotalDataUsed = usageRecord.TotalDataUsed,
                    DataLimit = usageRecord.DataLimit
                };
            }

            // Return null if no record was found to indicate the absence of data
            return null; // Consider enhancing this to handle a "not found" situation more gracefully
        }

    }
}
