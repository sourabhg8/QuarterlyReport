using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Sales
    {
        public List<SquareSales> SquareSales;
        public List<SquareSales> LifeStyles;
        public List<SalesComments> Comments;
    }
}