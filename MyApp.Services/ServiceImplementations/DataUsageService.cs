using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Domain.Entities;
using MyApp.Services.DTOs;
using MyApp.Services.ServiceInterfaces;
using System.Data;

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
        public CustomerUsageDTO? GetMonthlyDataUsageAsync(int customerId, int month, int year)
        {
            var usageRecords = _unitOfWork.Repository<MyApp.Domain.Entities.UsageRecords>().GetAllAsync();

            var customerUsageRecords = usageRecords.Where(c => c.CustomerID == customerId)
                    .Include(c=> c.Customer)
                        .ThenInclude(c=> c.CustomerPlan)
                            .ThenInclude(c=> c.Plan)
                    .ToList();

            if(customerUsageRecords != null && customerUsageRecords.Count() > 0)
            {
                var customerUsageRecord = customerUsageRecords
                       .Where(u => u.Date.Month == month && u.Date.Year == year) // Filter records to current month and year
                       .GroupBy(u => u.CustomerID) // Group by CustomerID to aggregate data per customer
                       .Select(group => new CustomerUsageDTO
                       {
                           CustomerId = group.Key, // Set CustomerId from the group key
                           FullName = group.First().Customer.FirstName + " " + group.First().Customer.LastName, // Concatenate first and last name from the first record in the group
                           TotalDataUsed = group.Sum(u => u.DataUsed),
                           DataLimit = group.First().Customer.CustomerPlan.Plan.DataLimit// Sum up the data used for each group to get total data usage,
                       })
                       .FirstOrDefault(); // Execute the query asynchronously and convert the result to a List

                if(customerUsageRecord != null)
                {
                    return customerUsageRecord;
                }
            }

            return null;
        }

    }
}
