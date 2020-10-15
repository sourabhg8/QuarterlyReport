using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class SpecialityLeasing
    {
        public Guid SpecialityLeasingId { get; set; }
        public string Tenant { get; set; }

        public string Sector { get; set;  }
        public string UnitNo { get; set;  }
        public string Gla { get; set; }

        public string Term { get; set;  }

        public string GrossRentBudget { get; set; }
        public string GrossRentActual { get; set; }

        public string SalesPercentage { get; set; }

        public string Comments { get; set; }

      
    }
}