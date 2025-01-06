using MyApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services.ServiceInterfaces
{
    public interface IDataUsageService
    {
        Task<CustomerUsageDTO?> GetMonthlyDataUsageAsync(int customerId, int month, int year);
    }
}
