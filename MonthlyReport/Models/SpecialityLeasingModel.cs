using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class SpecialityLeasingModel
    {
       public List<SpecialityLeasing> specialityLeasings { get; set; }
       public  List<SpecialProject> specialProjects { get; set; }
    }
}