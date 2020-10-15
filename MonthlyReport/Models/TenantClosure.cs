using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class TenantClosure
    {
        public Guid OpeningId { get; set; }
        public string Tenant { get; set; }

        public string Sector { get; set; }
        public string Gla { get; set; }
         public string DateOfClosure { get; set; }
        public string ReasonOfClosure { get; set; }

        public string Ar { get; set; }

        public string Occupancy { get; set; }
        public string CoTenancyRisk { get; set; }

        public string TI { get; set; }
        public string LLW { get; set; }
        public string Comments { get; set; }
    }
}