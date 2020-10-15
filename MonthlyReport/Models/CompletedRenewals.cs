using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class CompletedRenewals
    {
        public Guid OpeningId { get; set; }
        public string Months { get; set; }
        public string Tenant { get; set; }
        public string Sector { get; set; }
        public string UnitNo { get; set; }
        public string Gla { get; set; }
        public string Term { get; set; }
        public string NetBudget { get; set; }
        public string NetRentActual { get; set; }
        public string Ner { get; set; }
        public string Llw { get; set; }

        public string TA { get; set; }
        public string Commision { get; set; }
    }
}