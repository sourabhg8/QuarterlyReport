using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class FinancialLoan
    {
        public Guid LoanId { get; set; }
        public string Phase { get; set; }

        public string Lender { get; set;  }
        public string Loanbalance { get; set;  }
        public string Rate { get; set; }

        public string Term { get; set; }
        public string Expiryterm { get; set; }
        
        public string date { get; set; }
    }
}