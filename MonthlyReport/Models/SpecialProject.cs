using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class SpecialProject
    {
        public Guid ProjectId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}