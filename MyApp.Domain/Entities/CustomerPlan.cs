using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class CustomerPlan
    {
        // Foreign key related to the Customer entity and part of the composite key
        public int CustomerID { get; set; }

        // Foreign key related to the Plan entity and part of the composite key
        public int PlanID { get; set; }

        // Navigation properties
        public required Customer Customer { get; set; }
        public required Plans Plan { get; set; }
    }
}
