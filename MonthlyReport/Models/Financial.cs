using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Financial
    {
        public string importantUpdate { get; set; }

        public string masterPlanUpdate { get; set; }

        public List<Revenue> revenues { get; set; }
    }
}