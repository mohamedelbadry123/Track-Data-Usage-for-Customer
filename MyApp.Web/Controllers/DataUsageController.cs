using Microsoft.AspNetCore.Mvc;
using MyApp.Services.ServiceInterfaces;
using MyApp.Web.ViewModels;

namespace MyApp.Web.Controllers
{
    public class DataUsageController : Controller
    {
        private readonly IDataUsageService _dataUsageService;

        public DataUsageController(IDataUsageService dataUsageService)
        {
            _dataUsageService = dataUsageService;
        }

        /// <summary>
        /// Displays the monthly data usage for a specified customer and time period.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer whose data usage is to be retrieved.</param>
        /// <returns>
        /// A view displaying the customer's data usage. If no data is found, displays an error view.
        /// </returns>
        public async Task<IActionResult> Index(int customerId)
        {
            // Get current month
            var month = 12;

            // Get current month
            var year = 2024;

            // Retrieve monthly data usage from the service layer
            var usageData = _dataUsageService.GetMonthlyDataUsageAsync(customerId, month, year);

            // Check if usage data is available, otherwise return an error view
            if (usageData == null)
            {
                return View("Error"); // This can be customized to redirect to a specific error page or handle the error differently
            }

            // Prepare the data usage view model for the UI
            var viewModel = new DataUsageViewModel
            {
                CustomerId = usageData.CustomerId,
                FullName = usageData.FullName,
                TotalDataUsed = usageData.TotalDataUsed,
                DataLimit = usageData.DataLimit,
                IsNearLimit = (usageData.TotalDataUsed / usageData.DataLimit) > 0.7m, // Check if the usage is near the limit (e.g., above 90%)
                RecommendedPlan = (usageData.TotalDataUsed / usageData.DataLimit) > 1 ? "Premium Data Plan" : "Standard Plan" // Suggest a plan based on usage
            };

            // Render the view with the populated view model
            return View(viewModel);
        }

    }
}
