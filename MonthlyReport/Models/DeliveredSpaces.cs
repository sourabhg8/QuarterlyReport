using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class DeliveredSpaces
    {
        public Guid OpeningId { get; set; }
        public string Months { get; set; }
        public string Tenant { get; set; }
        public string Sector { get; set; }
        public string UnitNo { get; set; }
        public string Gla { get; set; }
        public string DeliveryDate { get; set; }
        public string FixturingPeriod { get; set; }
        public string ExpectedOpening { get; set; }
        public string Ner { get; set; }
        public string Llw { get; set; }

        public string TA { get; set; }
        public string Commision { get; set; }
    }
}