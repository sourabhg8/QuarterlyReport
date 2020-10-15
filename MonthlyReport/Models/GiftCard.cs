using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class GiftCard
    {
        public Guid cardid { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }

        public string Change1 { get; set; }
        public string Year1 { get; set; }
        public string Year2 { get; set; }
        public string Change2 { get; set; }

    }
}