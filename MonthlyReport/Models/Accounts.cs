using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Accounts
    {
        public string Tenant { get; set; }

        public string BalanceOverdue { get; set; }

        public string NetBalance { get; set; }

        public string Provision { get; set; }

        public string ReceivableBalance { get; set; }
        public string ThirtyDays { get; set; }
        public string SixtyDays { get; set; }
        public string NintyDays { get; set; }

        public string NintyPlusDays { get; set; }

        public string Comment { get; set; }

        public string Action { get; set; }
    }
}