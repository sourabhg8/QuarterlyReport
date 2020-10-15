using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Leasing
    {
        public List<NewTenantOpening> NewTenantOpenings { get; set; }
        public List<DeliveredSpaces> DeliveredSpaces { get; set; }
        public List<KeyDeals> keyDeals { get; set; }
        public List<CompletedRenewals> completedRenewals { get; set; }
        public List<HotDeals> hotDeals { get; set; }
        public List<TenantsAtRisk> tenantsAtRisks { get; set; }

        public List<TenantClosure> tenantClosures { get; set; }
    }
}