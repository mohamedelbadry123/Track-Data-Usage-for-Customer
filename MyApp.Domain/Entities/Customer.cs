using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Customer : BaseEntity
    {
        // First name of the customer
        public required string FirstName { get; set; }

        // Last name of the customer
        public required string LastName { get; set; }

        // Email address of the customer
        public required string Email { get; set; }

        public required CustomerPlan CustomerPlan { get; set; }

        public ICollection<UsageRecords> UsageRecords { get; set; } = new HashSet<UsageRecords>();
    }
}
