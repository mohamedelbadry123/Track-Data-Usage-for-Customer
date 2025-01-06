using Microsoft.AspNetCore.Mvc;
using MyApp.Services.ServiceInterfaces;
using MyApp.Web.ViewModels;

namespace MyApp.Web.Controllers
{
    public class CustomerUsageController : Controller
    {
        private readonly ICustomerUsageService _customerUsageService;

        public CustomerUsageController(ICustomerUsageService customerUsageService)
        {
            _customerUsageService = customerUsageService;
        }

        /// <summary>
        /// Asynchronous action method to handle requests for the root URL of this controller.
        /// This method retrieves customer data usage overviews and constructs a view model to display this data along with the current month.
        /// </summary>
        /// <returns>
        /// A view that displays customer data usage information for the current month.
        /// </returns>
        public async Task<IActionResult> Index()
        {
            // Call the service to get an overview of customer usage
            var usageOverview = await _customerUsageService.GetCustomerUsageOverviewAsync();

            // Prepare the view model with the data obtained from the service
            var viewModel = new CustomerUsageOverviewViewModel
            {
                Customers = usageOverview,
                CurrentMonth = DateTime.Now.ToString("MMMM yyyy") // Formatting current date to "Month Year" format
            };

            // Return the view with the populated view model
            return View(viewModel);
        }

    }
}
