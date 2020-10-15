using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Operations
    {
        public Guid OperationId { get; set; }
        public string Project { get; set; }
        public string CompletionDate { get; set; }
        public string ForecastCompletionDate { get; set; }
        public string Budget { get; set; }
        public string CommitToDate { get; set; }
        public string ApprovedAmount { get; set; }
        public string Comments { get; set; }
        public bool IsRecoverable { get; set; }

    }
}