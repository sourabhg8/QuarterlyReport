using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class SquareSales
    {
        public Guid squareid { get; set; }
        public string Tenant { get; set; }
        public string Gla { get; set; }
        public string sales1 { get; set; }
        public string Psf1 { get; set; }
        public string LY1 { get; set; }
        public string Sales2 { get; set; }
        public string PSF2 { get; set; }
        public string LY2 { get; set; }
        public string Sales3 { get; set; }
        public string PSF3 { get; set; }
        public string LY3 { get; set; }
        public string GrossRent { get; set; }
        public string PctRent { get; set; }
        public string Groc { get; set; }
    }
}