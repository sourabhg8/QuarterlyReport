using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class TenantsAtRisk
    {
        public Guid OpeningId { get; set; }
        public string Tenant { get; set; }
        public string UnitNo { get; set; }
        public string Gla { get; set; }
        public string Groc { get; set; }

        public string Sales { get; set; }

        public string RollingSales { get; set; }

        public string ArYtd { get; set; }

        public string Comments { get; set; }
    }
}