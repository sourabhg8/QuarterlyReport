using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Marketing
    {
        public Guid Marketingid { get; set; }
        public string TypeValue { get; set; }
        public string Type { get; set; }
        public string Kpi1 { get; set; }
        public string Kpi2 { get; set; }
        public string Kpi3 { get; set; }
        public string Result1 { get; set; }
        public string Result2 { get; set; }
        public string Result3 { get; set; }
    }
}