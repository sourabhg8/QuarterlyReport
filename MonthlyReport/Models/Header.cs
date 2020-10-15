using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Header
    {
        public int HeaderId { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Year1 { get; set; }
        public string Year2 { get; set; }
        public string Year3 { get; set; }
        public string Year4 { get; set; }
    }
}